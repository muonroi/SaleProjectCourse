using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebSaleRepository.Feature.AccountRepository;
using WebSaleRepository.Feature.CategoryRepository;
using WebSaleRepository.Feature.OrderRepository;
using WebSaleRepository.Feature.ProductRepository;
using WebSaleRepository.Feature.UserRepository;
using WebSaleRepository.Interfaces.Accounts;
using WebSaleRepository.Interfaces.Categories;
using WebSaleRepository.Interfaces.Orders;
using WebSaleRepository.Interfaces.Products;
using WebSaleRepository.Interfaces.Users;
using WebSaleRepository.Models;
using WebSaleRepository.Services;
using WebSaleRepository.Services.Interfaces;

namespace WebSaleRepository
{
    public static class ConfigRepository
    {
        public static IServiceCollection RepositoryConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            //Depedency Injection --> DI

            _ = services.AddScoped<IProductRepository, ProductRepository>();
            _ = services.AddScoped<IAccountRepository, AccountRepository>();
            _ = services.AddScoped<IOrderRepository, OrderRepository>();
            _ = services.Configure<SendGridSetting>(configuration.GetSection(nameof(SendGridSetting)));
            _ = services.AddScoped<IEmailService, EmailService>();
            _ = services.AddScoped<ICategoryRepository, CategoryRepository>();
            _ = services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}