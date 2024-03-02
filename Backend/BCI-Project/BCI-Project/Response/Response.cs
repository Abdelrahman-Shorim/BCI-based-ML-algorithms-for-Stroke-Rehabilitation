namespace BCI_Project.Response
{
    public class Response<T> where T : class
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public ICollection<string> Errors { get; set; }
    }
}
