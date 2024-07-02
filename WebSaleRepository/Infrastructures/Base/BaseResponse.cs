using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WebSaleRepository.Helper;
using WebSaleRepository.Models;
using WebSaleRepository.Responses.Accounts;
using WebSaleRepository.Settings;

namespace WebSaleRepository.Infrastructures.Base
{
    public abstract class BaseRepository
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;

        protected readonly IConfiguration _configuration;

        public BaseRepository(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

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

        protected TokenInfoModel GetCurrentRoleInfo()
        {
            TokenInfo tokenInfo = ManagerTokenHelper.GetTokenInfo(_httpContextAccessor, _configuration);

            bool isRoleAdmin = tokenInfo.Role == RoleSettings.AdminRole;
            TokenInfoModel result = new TokenInfoModel
            {
                IsAdminRole = isRoleAdmin,
                TokenInfo = tokenInfo
            };
            return result;
        }
    }
}