using KoperasiTentera.DataAccess.DTOs;

namespace KoperasiTentera.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IcNumber { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public User? User { get; set; }
    }
}
