using System.ComponentModel.DataAnnotations.Schema;

namespace KoperasiTentera.DataAccess.DTOs
{
    [Table("Customers")]
    public class CustomerDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IcNumber { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public virtual UserDto User { get; set; }
    }
}
