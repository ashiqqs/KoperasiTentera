using KoperasiTentera.DataAccess.DTOs;

namespace KoperasiTentera.DataAccess.Repositories
{
    public interface ICustomerRepository : IRepository<CustomerDto>
    {
        CustomerDto Registration(CustomerDto customer);
    }
}
