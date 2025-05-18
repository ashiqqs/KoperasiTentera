using System.ComponentModel.DataAnnotations.Schema;

namespace KoperasiTentera.DataAccess.DTOs
{
    [Table("OtpRequests")]
    public class OtpRequestDto : BaseDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OtpMethod { get; set; }
        public string Code { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
