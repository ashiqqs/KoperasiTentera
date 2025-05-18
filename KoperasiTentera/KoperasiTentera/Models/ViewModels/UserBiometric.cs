using KoperasiTentera.DataAccess.DTOs;

namespace KoperasiTentera.Models
{
    public class UserBiometric
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BiometricType { get; set; }
        public string BiometricData { get; set; }

        public User User { get; set; }
    }
}
