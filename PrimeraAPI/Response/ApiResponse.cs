namespace PrimeraAPI.Response
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public long InternalCode { get; set; } = 0;
        public bool IsSuccess => Data != null!;

        private ApiResponse(string message, long internalcode , T? data = default)
        {
            Message = message;
            InternalCode = internalcode;
            Data = data;
        }

        public static ApiResponse<T> Success(T data) => new ApiResponse<T>(string.Empty, 200, data);

        public static ApiResponse<T> Failure(long internalcode, string message) => new ApiResponse<T>(message, internalcode);
    }
}

