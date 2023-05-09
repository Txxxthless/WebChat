namespace back_api.Domain.Entity
{
    public class DataBaseResponse<T> where T : class
    {
        public bool Succeeded { get; set; }
        public string Description { get; set; }
        public T Data { get; set; }
    }
}
