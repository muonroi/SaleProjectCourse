using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebSaleAdmin.Interfaces;
using WebSaleAdmin.Models.Base;
using WebSaleAdmin.Models.Requests.Accounts;
using WebSaleAdmin.Models.Responses.Accounts;
using WebSaleAdmin.Models.Views.Accounts;

namespace WebSaleAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("LoginInputForm");
        }

        public ActionResult LoginInputForm()
        {
            return View(new LoginInput());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInput loginInput)
        {
            TResponse<LoginResponse> loginResponse = new TResponse<LoginResponse>();
            if (ModelState.IsValid)
            {
                loginResponse = await _accountService.LoginAsync(new LoginRequest
                {
                    Username = loginInput.Username,
                    Password = loginInput.Password
                });
            }
            return View(loginResponse);
        }
    }
}