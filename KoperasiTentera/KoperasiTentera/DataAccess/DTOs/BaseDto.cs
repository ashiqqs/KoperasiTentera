namespace KoperasiTentera.DataAccess.DTOs
{
    public abstract class BaseDto
    {
        public BaseDto() { 
            CreatedAt = DateTime.Now;
        }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
