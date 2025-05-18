using KoperasiTentera.DataAccess.DTOs;

namespace KoperasiTentera.Models.Factories
{
    public interface IUserFactory : IMappingFactory<User, UserDto>
    {
        UserDto CreateDefaultFor(int customerId);
    }
}
