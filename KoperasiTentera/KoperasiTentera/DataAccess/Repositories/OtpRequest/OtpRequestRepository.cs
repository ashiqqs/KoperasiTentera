using KoperasiTentera.DataAccess.DTOs;

namespace KoperasiTentera.DataAccess.Repositories
{
    public class OtpRequestRepository: Repository<OtpRequestDto>, IOtpRequestRepository
    {
        public OtpRequestRepository(SqlDbContext dbContext): base (dbContext, dbContext.OtpRequests)
        {
            
        }
    }
}
