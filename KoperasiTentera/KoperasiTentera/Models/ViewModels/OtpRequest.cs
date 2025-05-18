using KoperasiTentera.Utils.Enums;

namespace KoperasiTentera.Models
{
    public class OtpRequest
    {
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public int OtpMethod { get; set; }
        public string Code { get; set; }
        public bool IsUsed { get; set; }
    }

    public class CustomerOtpRequest
    {
        public CustomerOtpRequest()
        {
            
        }
        public CustomerOtpRequest(int customerId, OtpMethod method)
        {
            CustomerId = customerId;
            OtpMethod = (int)method;
        }
        public int CustomerId { get; set; }
        public int OtpMethod { get; set; }
    }

    public class OtpVerifyRequest : CustomerOtpRequest
    {
        public string Code { get; set; }
    }

}
