using System;

namespace WebSaleAdmin.Models.Base
{
    public class TResponse<T>
    {
        public Guid Id { get; set; }
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public T Data { get; set; }

        public DateTime UtcTime { get; set; }

        public TResponse()
        {
        }

        public TResponse(int statusCode, string message = "")
        {
            Id = Guid.NewGuid();
            StatusCode = statusCode;
            Message = message;
            IsSuccess = false;
            Data = default;
            UtcTime = DateTime.UtcNow;
        }

        public TResponse(int statusCode, string message, bool isSuccess, T data)
        {
            Id = Guid.NewGuid();
            StatusCode = statusCode;
            Message = message;
            IsSuccess = isSuccess;
            Data = data;
            UtcTime = DateTime.UtcNow;
        }
    }
}