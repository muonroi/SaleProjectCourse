using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Models;
using WebSaleRepository.Services.Interfaces;

namespace WebSaleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public SenderController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-bulk-from-excel")]
        public async Task<IActionResult> SendBulkEmailFromExcel([FromForm] IFormFile file)
        {
            TResponse<bool> response = await _emailService.SendBulkEmailFromExcelFile(file);
            return Ok(response);
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailModel email)
        {
            TResponse<bool> response = await _emailService.SendEmail(email);
            return Ok(response);
        }
    }
}
