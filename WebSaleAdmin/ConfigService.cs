using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebSaleAdmin.Interfaces;
using WebSaleAdmin.Services;

namespace WebSaleAdmin
{
    public static class ConfigService
    {
        public static IServiceCollection ServiceConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            _ = services.AddScoped<IAccountService, AccountService>();
            return services;
        }
    }
}