namespace KoperasiTentera.Models
{
    public class Response<T>
    {
        public Response()
        {
            Errors = new();
        }
        public bool IsSuccess { get; set; }
        public T? Result { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
    }
}
