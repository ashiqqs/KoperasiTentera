using KoperasiTentera.DataAccess.DTOs;

namespace KoperasiTentera.Models.Factories
{
    public interface IOtpFactory: IMappingFactory<OtpRequest, OtpRequestDto>
    {
        OtpRequestDto Create(CustomerOtpRequest customerOtpRequest);
    }
}
