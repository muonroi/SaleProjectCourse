using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Interfaces.Users;
using WebSaleRepository.Requests.Users;

namespace WebSaleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UpdateUserRequest request, [FromQuery] string username)
        {
            TResponse<bool> response = await _userRepository.EditUserByUsernameAsync(request, username);
            return Ok(response);
        }
    }
}