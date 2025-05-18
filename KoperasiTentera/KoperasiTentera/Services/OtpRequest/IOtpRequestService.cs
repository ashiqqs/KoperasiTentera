using KoperasiTentera.DataAccess.DTOs;
using KoperasiTentera.Models;

namespace KoperasiTentera.Services
{
    public interface IOtpRequestService
    {
        OtpRequest Create(CustomerOtpRequest otpRequest);
        Response<string> RequestOTP(CustomerOtpRequest otpRequest);
        Response<bool> VerifyOTP(OtpVerifyRequest otpVerifyRequest);
    }
}
