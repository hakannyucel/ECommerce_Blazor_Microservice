namespace Common.Models
{
    public class ApiModel<T> where T : class
    {
        public bool IsResult { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public class ApiSearchModel<T> where T : class
    {
        public bool IsResult { get; set; }
        public string Message { get; set; }
    }

    public class PageableModel<T> where T : class
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool IsNext { get; set; }
        public bool IsPrevious { get; set; }
        public IReadOnlyList<T> Data { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
    }

    public class PageRequest
    {
        public int Size { get; set; }
        public int Page { get; set; }
    }
}
