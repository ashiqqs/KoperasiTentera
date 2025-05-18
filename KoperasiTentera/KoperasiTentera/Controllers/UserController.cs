using KoperasiTentera.Models;
using KoperasiTentera.Models.ViewModels;
using KoperasiTentera.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoperasiTentera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IOtpRequestService _otpService;
        private readonly IUserService _userService;

        public UserController(
            IUserService userService,
            IOtpRequestService otpService)
        {
            _userService = userService;
            _otpService = otpService;
        }

        [HttpPost("VerifyOTP")]
        public IActionResult VerifyOTP(OtpVerifyRequest verifyRequest)
        {
            var verifyRespponse = _otpService.VerifyOTP(verifyRequest);
            return Ok(verifyRespponse);
        }


        [HttpPost("RequestOTP")]
        public IActionResult RequestOTP(CustomerOtpRequest customerOtpRequest)
        {
            var response = _otpService.RequestOTP(customerOtpRequest);
            return Ok(response);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest request)
        {
            var response = _userService.Login(request);
            return Ok(response);
        }

        [HttpPost("Update")]
        public IActionResult Update(User user)
        {
            var response = _userService.UpdateUser(user);
            return Ok(response);
        }

        [HttpPost("VerifyUserPIN")]
        public IActionResult VerifyUserPin(VerifyUserPinRequest verifyUserPinRequest)
        {
            var response = _userService.VerifyPin(verifyUserPinRequest);
            return Ok(response);
        }

        [HttpPost("SetPIN")]
        public IActionResult SetPIN(PinSetRequest pinSetRequest)
        {
            var response = _userService.SetUserPIN(pinSetRequest);
            return Ok(response);
        }
    }
}
