using FluentValidation;
using KoperasiTentera.DataAccess.Repositories;
using KoperasiTentera.Models;
using KoperasiTentera.Models.Factories;
using KoperasiTentera.Models.ViewModels;
using KoperasiTentera.Utils.Enums;

namespace KoperasiTentera.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<Customer> _customerValidator;
        private readonly ICustomerFactory _customerFactory;
        private readonly IOtpRequestService _otpRequestService;
        public CustomerService(ICustomerRepository customerRepository,
            IValidator<Customer> customerValidator,
            ICustomerFactory customerFactory,
            IOtpRequestService otpRequestService)
        {
            _customerRepository = customerRepository;
            _customerValidator = customerValidator;
            _customerFactory = customerFactory;
            _otpRequestService = otpRequestService;
        }
        public RegistrationResponse Registration(Customer customer)
        {
            RegistrationResponse response = new();

            if (customer is null)
            {
                response.IsSuccess = false;
                response.Message = "Invalid input for customer";
                return response;
            }

            var existCustomer = _customerRepository.GetAsync(cust => cust.IcNumber == customer.IcNumber)?.Result?.FirstOrDefault();
            if (existCustomer != null)
            {
                response.IsSuccess = true;
                response.Result = _customerFactory.Create(existCustomer);
                response.IsExist = true;
                return response;
            }

            var validationResult = _customerValidator.Validate(customer);

            if (validationResult.IsValid)
            {
                var customerDto = _customerFactory.Create(customer);
                var saveResult = _customerRepository.Registration(customerDto);

                if (saveResult != null)
                {
                    var customerOtpRequest = new CustomerOtpRequest(saveResult.Id, OtpMethod.ContactNumber);
                    var otpSaveResult = _otpRequestService.Create(customerOtpRequest);
                    if (otpSaveResult != null) {
                        //TODO: Send OTP
                        response.IsSMSOtpSent = true;
                    }
                    response.IsSuccess = true;
                    response.Result = _customerFactory.Create(saveResult);
                    response.Message = "Customer created successfully";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Failed to create customer";
                }
            }
            else
            {
                response.IsSuccess = false;
                validationResult.Errors?.ForEach(err =>
                {
                    response.Errors.Add(err.ErrorMessage);
                });
                response.Message = "Failed to create customer";
            }
            return response;
        }

        public Customer Get(int id)
        {
            var customerDto = _customerRepository.GetByIdAsync(id).Result;
            if (customerDto is null)
                return null;

            var customer = _customerFactory.Create(customerDto);
            return customer;
        }
    }
}
