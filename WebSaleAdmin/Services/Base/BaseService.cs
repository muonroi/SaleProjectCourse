using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace WebSaleAdmin.Services.Base
{
    public abstract class BaseService
    {
        protected ILogger<BaseService> _logger;
        protected static readonly HttpClient _httpClient = new HttpClient();

        protected BaseService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BaseService>();
        }
    }
}