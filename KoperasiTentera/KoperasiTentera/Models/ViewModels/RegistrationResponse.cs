namespace KoperasiTentera.Models.ViewModels
{
    public class RegistrationResponse : Response<Customer?>
    {
        public bool IsExist { get; set; }
        public bool IsSMSOtpSent { get; set; }
    }
}
