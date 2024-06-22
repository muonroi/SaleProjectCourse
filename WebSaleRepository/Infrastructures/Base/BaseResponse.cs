using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebSaleRepository.Infrastructures.Base
{
    public class BaseRepository
    {

        protected static Task<TResponse<T>> OK<T>(T data, string message = "")
        {
            return Task.FromResult(new TResponse<T>(StatusCodes.Status200OK, message, true, data));
        }

        protected static Task<TResponse<T>> Fail<T>(string message, params object[] arguments)
        {
            string customMessage = arguments != null
                                    && arguments.Length > 0 ?
                                    string.Format(message, arguments)
                                    : message;
            TResponse<T> response = new TResponse<T>(StatusCodes.Status400BadRequest, customMessage);

            return Task.FromResult(response);
        }

        protected static Task<TResponse<T>> Fail<T>(string message, int statusCode, params object[] arguments)
        {
            string customMessage = arguments != null
                                    && arguments.Length > 0 ?
                                    string.Format(message, arguments)
                                    : message;
            TResponse<T> response = new TResponse<T>(statusCode, customMessage);

            return Task.FromResult(response);
        }
    }
}