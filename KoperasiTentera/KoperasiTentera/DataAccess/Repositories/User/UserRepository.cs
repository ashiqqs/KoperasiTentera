using KoperasiTentera.DataAccess.DTOs;

namespace KoperasiTentera.DataAccess.Repositories
{
    public class UserRepository : Repository<UserDto>, IUserRepository
    {
        public UserRepository(SqlDbContext dbContext): base(dbContext, dbContext.Users)
        {
            
        }
    }
}
