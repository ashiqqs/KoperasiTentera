using KoperasiTentera.Models;
using KoperasiTentera.Models.ViewModels;

namespace KoperasiTentera.Services
{
    public interface ICustomerService
    {
        RegistrationResponse Registration(Customer customer);
        Customer Get(int id);
    }
}
