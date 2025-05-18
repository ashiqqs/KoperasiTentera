using System.ComponentModel.DataAnnotations.Schema;

namespace KoperasiTentera.DataAccess.DTOs
{
    [Table("UserBiometrics")]
    public class UserBiometricDto : BaseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BiometricType { get; set; }
        public string BiometricData { get; set; } 

        public virtual UserDto User { get; set; }
    }
}
