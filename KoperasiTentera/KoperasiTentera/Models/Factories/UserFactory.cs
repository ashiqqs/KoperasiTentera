using AutoMapper;
using KoperasiTentera.DataAccess.DTOs;

namespace KoperasiTentera.Models.Factories
{
    public class UserFactory : MappingFactory<User, UserDto>, IUserFactory
    {
        public UserFactory(IMapper mapper) : base(mapper) { }
        public UserDto CreateDefaultFor(int customerId)
        {
            UserDto dto = new UserDto();
            dto.CustomerId = customerId;
            return dto;
        }
    }
}
