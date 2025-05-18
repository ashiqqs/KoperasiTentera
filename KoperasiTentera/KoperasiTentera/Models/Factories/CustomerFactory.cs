using AutoMapper;
using KoperasiTentera.DataAccess.DTOs;

namespace KoperasiTentera.Models.Factories
{
    public class CustomerFactory: MappingFactory<Customer, CustomerDto>, ICustomerFactory
    {
        public CustomerFactory(IMapper mapper): base(mapper) { }


    }
}
