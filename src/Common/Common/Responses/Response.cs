namespace Common.Responses
{
    public class Response
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public Response()
        {
        }

        public Response(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public Response(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }

    public class Response<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }

        public Response()
        {
        }

        public Response(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public Response(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public Response(bool isSuccess, T data)
        {
            IsSuccess = isSuccess;
            Data = data;
        }

        public Response(T data)
        {
            IsSuccess = true;
            Data = data;
        }

        public Response(bool isSuccess, string message, T data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }
    }
}
