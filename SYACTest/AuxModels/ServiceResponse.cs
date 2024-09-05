namespace SYACTest.AuxModels
{
    public class ServiceResponse<T>
    {
        public int statusCode { get; set; }
        public string? messages { get; set; }
        public T? data { get; set; }
    }
}
