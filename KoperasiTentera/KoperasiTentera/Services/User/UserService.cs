using KoperasiTentera.DataAccess.Repositories;
using KoperasiTentera.Models;
using KoperasiTentera.Models.Factories;

namespace KoperasiTentera.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerrepository;
        private readonly IUserFactory _userFactory;
        private readonly ICustomerFactory _customerFactory;

        public UserService(
            IUserRepository userRepository,
            ICustomerRepository customerRepository,
            IUserFactory userFactory,
            ICustomerFactory customerFactory)
        {
            _userRepository = userRepository;
            _customerrepository = customerRepository;
            _userFactory = userFactory;
            _customerFactory = customerFactory;
        }
        public Response<User> Login(LoginRequest loginRequest)
        {
            Response<User> response = new();
            if (loginRequest is null)
            {
                response.IsSuccess = false;
                response.Errors.Add("Invalid login request");
                return response;
            }
            var customer = _customerrepository.GetAsync(cust => cust.IcNumber == loginRequest.IcNumber)?.Result?.FirstOrDefault();
            if (customer != null)
            {
                var userDto = _userRepository.GetAsync(user => user.CustomerId == customer.Id)?.Result?.FirstOrDefault();
                if (userDto != null)
                {
                    response.IsSuccess = true;
                    response.Result = _userFactory.Create(userDto);
                    return response;
                }
            }
            response.IsSuccess = false;
            response.Errors.Add("IC Number not registered");
            return response;
        }

        public Response<User> SetUserPIN(PinSetRequest pinRequest)
        {
            Response<User> response = new();

            var userDto = _userRepository.GetByIdAsync(pinRequest.UserId)?.Result;
            if (userDto != null)
            {
                var user = _userFactory.Create(userDto);
                var dto = _userFactory.Create(user);
                dto.PIN = pinRequest.PIN;
                var updateResult = _userRepository.UpdateAsync(dto.Id, dto).Result;
                if (updateResult != null)
                {
                    response.IsSuccess = true;
                    response.Result = _userFactory.Create(dto);
                    return response;
                }
            }
            return response;
        }

        public Response<User> UpdateUser(User user)
        {
            Response<User> response = new();
            if (user is null)
            {
                response.IsSuccess = false;
                response.Errors.Add("Invalid login request");
                return response;
            }

            var userDto = _userFactory.Create(user);
            var updatedResult = _userRepository.UpdateAsync(userDto.Id, userDto)?.Result;
            if (updatedResult != null)
            {
                response.IsSuccess = true;
                response.Result = _userFactory.Create(updatedResult);
                return response;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add("Failed to update user");
            }
            return response;
        }

        public Response<Customer> VerifyPin(VerifyUserPinRequest request)
        {
            Response<Customer> response = new();
            if (request is null)
            {
                response.IsSuccess = false;
                response.Errors.Add("Invalid PIN verification request");
                return response;
            }

            var userDto = _userRepository.GetAsync(user => user.Id == request.UserId && user.PIN == request.PIN)?.Result?.FirstOrDefault();

            if (userDto != null)
            {
                var user = _userFactory.Create(userDto);
                var customerDto = _customerrepository.GetByIdAsync(user.CustomerId)?.Result;
                if (customerDto != null)
                {
                    var customer = _customerFactory.Create(customerDto);

                    response.IsSuccess = true;
                    response.Result = customer;
                    return response;
                }
            }
            response.IsSuccess = false;
            response.Errors.Add("Incorrect PIN");

            return response;

        }
    }
}
