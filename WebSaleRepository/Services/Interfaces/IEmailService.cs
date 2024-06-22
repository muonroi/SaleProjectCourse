using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Models;

namespace WebSaleRepository.Services.Interfaces
{
    public interface IEmailService
    {
        Task<TResponse<bool>> SendBulkEmailFromExcelFile(IFormFile file);
        Task<TResponse<bool>> SendEmail(EmailModel emailModel);
    }
}
