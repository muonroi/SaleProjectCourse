using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Interfaces.Accounts;
using WebSaleRepository.Requests.Accounts;
using WebSaleRepository.Responses.Accounts;

namespace WebSaleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            TResponse<LoginResponse> response = await _accountRepository.LoginAsync(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateAccountInfoRequest request)
        {
            TResponse<UpdateAccountInfoResponse> response = await _accountRepository.UpdateAccountInfo(request);
            return Ok(response);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            TResponse<RegisterResponse> response = await _accountRepository.RegisterAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUsers([FromQuery] int pageIndex = 1, int pageSize = 10)
        {
            TResponse<GetCurrentUserPagingRespone> response = await _accountRepository.GetCurrentAccountAsync(pageIndex, pageSize);
            return Ok(response);
        }

    }
}
