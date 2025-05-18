using KoperasiTentera.DataAccess.DTOs;
using KoperasiTentera.DataAccess.Repositories;
using KoperasiTentera.Models;
using KoperasiTentera.Models.Factories;
using KoperasiTentera.Utils.Enums;
using System.Security.Cryptography;
using System.Text;

namespace KoperasiTentera.Services
{
    public class OtpRequestService : IOtpRequestService
    {
        private readonly IOtpRequestRepository _otpRequestRepo;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOtpFactory _otpFactory;

        public OtpRequestService(
            IOtpRequestRepository otpRequestRepo,
            ICustomerRepository customerRepository,
            IUserRepository userRepository,
            IOtpFactory optFactory)
        {
            _otpRequestRepo = otpRequestRepo;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _otpFactory = optFactory;
        }

        public OtpRequest Create(CustomerOtpRequest otpRequest)
        {
            var otpRequestDto = _otpFactory.Create(otpRequest);
            var otpSaveResult = _otpRequestRepo.CreateAsync(otpRequestDto)?.Result;

            if (otpSaveResult != null)
            {
                return _otpFactory.Create(otpSaveResult);
            }

            return null;
        }

        public Response<string> RequestOTP(CustomerOtpRequest customerOtpRequest)
        {
            var requestResponse = Create(customerOtpRequest);

            Response<string> response = new();

            if (requestResponse != null)
            {
                CustomerDto customer = _customerRepository.GetByIdAsync(customerOtpRequest.CustomerId).Result;
                string maskedOtpReceiver = string.Empty;
                if (customer != null) {
                    switch (customerOtpRequest.OtpMethod)
                    {
                        case (int)OtpMethod.Email:
                            maskedOtpReceiver = MaskEmail(customer.Email);
                            break;
                        case (int)OtpMethod.ContactNumber:
                            maskedOtpReceiver = MaskContactNumber(customer.ContactNumber);
                            break;
                    }
                }

                //TODO: send OTP
                
                response.IsSuccess = true;
                response.Message = $"Enter 4-digit code sent to {maskedOtpReceiver}";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Failed to create OTP request";
            }
            return response;
        }

        public Response<bool> VerifyOTP(OtpVerifyRequest otpVerifyRequest)
        {
            var response = new Response<bool>();

            if (otpVerifyRequest is null)
            {
                response.IsSuccess = false;
                response.Result = false;
                response.Errors.Add("Invalid OTP verification request.");
                return response;
            }

            var otpRequet = _otpRequestRepo.GetAsync(otp => otp.CustomerId == otpVerifyRequest.CustomerId 
            && otp.OtpMethod == otpVerifyRequest.OtpMethod 
            && otp.Code == otpVerifyRequest.Code
            && otp.ExpiredAt > DateTime.Now)?.Result?.FirstOrDefault();

            if (otpRequet != null)
            {
                otpRequet.IsUsed = true;
                _otpRequestRepo.UpdateAsync(otpRequet.Id, otpRequet);

                var userDto = _userRepository.GetAsync(user => user.CustomerId == otpVerifyRequest.CustomerId)?.Result?.FirstOrDefault();
                if (userDto != null)
                {
                    if (otpVerifyRequest.OtpMethod == (int)OtpMethod.Email)
                        userDto.EmailVerified = true;
                    if (otpVerifyRequest.OtpMethod == (int)OtpMethod.ContactNumber)
                        userDto.ContactVerified = true;

                    _userRepository.UpdateAsync(userDto.Id, userDto);
                }

                string verifiedMethod = string.Empty;
                switch (otpVerifyRequest.OtpMethod)
                {
                    case (int)OtpMethod.ContactNumber:
                        verifiedMethod = "Contact Number";
                        break;
                    case (int)OtpMethod.Email:
                        verifiedMethod = "Email";
                        break;
                }

                response.IsSuccess = true;
                response.Result = true;
                response.Message = $"{verifiedMethod} verified successfully";
            }

            return  response;
        }

        private string MaskContactNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length <= 4)
            {
                return phoneNumber;
            }

            string maskedChar = new string('*', phoneNumber.Length - 4);
            return $"{maskedChar}{phoneNumber[^4..]}";
        }

        private string MaskEmail(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress) || emailAddress.Length <= 6)
            {
                return emailAddress;
            }

            string maskedChar = new string('*', emailAddress.Length - 6);
            return $"{emailAddress.Substring(0, 2)}{maskedChar}{emailAddress[^4..]}";
        }
    }
}
