namespace KoperasiTentera.Models
{
    public class LoginRequest
    {
        public string IcNumber { get; set; }
    }

    public class VerifyUserPinRequest
    {
        public int UserId { get; set; }
        public string PIN { get; set; }
    }

    public class PinSetRequest
    {
        public int UserId { get; set; }
        public string PIN { get; set; }
    }

}
