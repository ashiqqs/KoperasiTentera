using System.ComponentModel.DataAnnotations.Schema;

namespace KoperasiTentera.DataAccess.DTOs
{
    [Table("Users")]
    public class UserDto : BaseDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? PIN { get; set; }
        public bool BiometricEnabled { get; set; }
        public bool ContactVerified { get; set; }
        public bool EmailVerified { get; set; }

        public virtual CustomerDto Customer { get; set; }

        //public virtual IEnumerable<UserBiometricDto> UserBiometrics { get; set; }
    }
}
