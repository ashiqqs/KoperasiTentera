using KoperasiTentera.DataAccess.DTOs;
using KoperasiTentera.Models;
using KoperasiTentera.Models.ViewModels;

namespace KoperasiTentera.Services
{
    public interface IUserService
    {
        Response<User> UpdateUser(User user);
        Response<User> Login(LoginRequest loginRequest);
        Response<Customer> VerifyPin(VerifyUserPinRequest user);
        Response<User> SetUserPIN(PinSetRequest pinRequest);
    }
}
