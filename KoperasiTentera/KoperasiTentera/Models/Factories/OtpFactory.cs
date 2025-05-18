using AutoMapper;
using KoperasiTentera.DataAccess.DTOs;
using System.Text;

namespace KoperasiTentera.Models.Factories
{
    public class OtpFactory : MappingFactory<OtpRequest, OtpRequestDto>, IOtpFactory
    {
        private const int OTP_LIFE_IN_MINITUTE = 5;
        public OtpFactory(IMapper mapper) : base(mapper) { }
        public OtpRequestDto Create(CustomerOtpRequest customerOtpRequest)
        {
            if (customerOtpRequest == null)
                return null;

            OtpRequestDto dto = new OtpRequestDto();
            dto.OtpMethod = customerOtpRequest.OtpMethod;
            dto.CustomerId = customerOtpRequest.CustomerId;
            dto.Code = GenerateRandomOtp();
            dto.IsUsed = false;
            dto.ExpiredAt = DateTime.Now.AddMinutes(OTP_LIFE_IN_MINITUTE);

            return dto;
        }


        private string GenerateRandomOtp()
        {
            StringBuilder randomCode = new();
            Random random = new();

            for (int i = 0; i < 4; i++)
            {
                randomCode.Append(random.Next(0, 9));
            }
            return randomCode.ToString();
        }
    }
}
