using AutoMapper;
using KoperasiTentera.DataAccess.DTOs;

namespace KoperasiTentera.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<OtpRequestDto, OtpRequest>().ReverseMap();
        }
    }
}
