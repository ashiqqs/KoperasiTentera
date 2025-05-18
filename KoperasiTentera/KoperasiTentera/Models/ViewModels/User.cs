using KoperasiTentera.DataAccess.DTOs;

namespace KoperasiTentera.Models
{
    public class User
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public bool ContactVerified { get; set; }
        public bool EmailVerified { get; set; }
        public bool BiometricEnabled { get; set; }
    }
}
