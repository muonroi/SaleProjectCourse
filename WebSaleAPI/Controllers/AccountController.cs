using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetCurrentUsers([FromQuery] string keyword, int pageIndex = 1, int pageSize = 10)
        {
            TResponse<GetCurrentUserPagingRespone> response = await _accountRepository.GetCurrentAccountAsync(keyword, pageIndex, pageSize);
            return Ok(response);
        }

        [HttpGet("roles-list")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCurrentRole([FromQuery] string input)
        {
            TResponse<List<GetCurrentRolesRespone>> response = await _accountRepository.GetCurrentRolesAsync(input);
            return Ok(response);
        }

        [HttpPost("role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            TResponse<bool> response = await _accountRepository.CreateaRolesAsync(request);
            return Ok(response);
        }

        [HttpPut("role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleRequest request)
        {
            TResponse<bool> response = await _accountRepository.UpdateRolesAsync(request);
            return Ok(response);
        }

        [HttpDelete("role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveRole([FromQuery] long roleId)
        {
            TResponse<bool> response = await _accountRepository.RemoveRolesAsync(roleId);
            return Ok(response);
        }

        [HttpPatch("role-assign")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRolesRequest request)
        {
            TResponse<bool> response = await _accountRepository.AssignRolesAsync(request);
            return Ok(response);
        }

        [HttpGet("account-status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AccoutStatisticStatus([FromQuery] GetStatisticAccountStatusRequest request)
        {
            TResponse<List<GetStatisticAccountStattusResponse>> response = await _accountRepository.StatisticAccountStatus(request);
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveAccount([FromQuery] string username)
        {
            TResponse<bool> response = await _accountRepository.RemoveAccountAsync(username);
            return Ok(response);
        }

        [HttpPatch("lock")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> LockAccount([FromBody] LockAccountRequest request)
        {
            TResponse<bool> response = await _accountRepository.LockAccountAsync(request.Username);
            return Ok(response);
        }
    }
}