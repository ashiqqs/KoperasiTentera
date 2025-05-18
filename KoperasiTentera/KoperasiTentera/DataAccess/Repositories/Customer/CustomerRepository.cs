using KoperasiTentera.DataAccess.DTOs;
using KoperasiTentera.Models.Factories;

namespace KoperasiTentera.DataAccess.Repositories
{
    public class CustomerRepository : Repository<CustomerDto>, ICustomerRepository
    {
        private readonly IUserFactory _userFactory;
        public CustomerRepository(SqlDbContext dbContext, IUserFactory userFactory) :base(dbContext, dbContext.Customers)
        {
            _userFactory = userFactory;
        }

        public CustomerDto Registration(CustomerDto customer)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Customers.Add(customer);
                    _dbContext.SaveChanges();
                    var userDto = _userFactory.CreateDefaultFor(customer.Id);
                    _dbContext.Users.Add(userDto);

                    bool isSaved = _dbContext.SaveChanges() > 0;
                    if (isSaved)
                        transaction.Commit();
                    else transaction.Rollback();
                }
                catch (Exception ex) {
                    transaction.Rollback();
                }
            }
            return customer;
        }
    }
}
