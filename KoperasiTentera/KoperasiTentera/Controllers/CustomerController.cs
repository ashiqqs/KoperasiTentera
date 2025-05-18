using KoperasiTentera.Models;
using KoperasiTentera.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoperasiTentera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("Registration")]
        public IActionResult Registration(Customer customer)
        {
            var response = _customerService.Registration(customer);
            return Ok(response);
        }
    }
}
