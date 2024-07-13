using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebSaleAdmin.Interfaces;
using WebSaleAdmin.Models.Base;
using WebSaleAdmin.Models.Requests.Accounts;
using WebSaleAdmin.Models.Responses.Accounts;
using WebSaleAdmin.Models.Views.Accounts;

namespace WebSaleAdmin.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountService _accountService;

        public AdminController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            string currentToken = GetTokenFromSession();
            string currentUserInfo = Request.Cookies["UserInfo"];
            return (string.IsNullOrEmpty(currentToken) || string.IsNullOrEmpty(currentUserInfo)) ? RedirectToAction("Login") : (IActionResult)View();
        }

        public ActionResult Login()
        {
            return View(new LoginInput());
        }

        public async Task<IActionResult> Login(LoginInput loginInput)
        {
            TResponse<LoginResponse> result = new TResponse<LoginResponse>();
            if (ModelState.IsValid)
            {
                result = await _accountService.LoginAsync(new LoginRequest
                {
                    Username = loginInput.Username,
                    Password = loginInput.Password
                });
            }
            if (result.StatusCode == 200)
            {
                SaveInfoLogin(result.Data);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("LoginError", result.Message);
                return View("Login", loginInput);
            }
        }

        public ActionResult Register()
        {
            return View(new RegisterInput());
        }

        public async Task<IActionResult> Register(RegisterInput registerInput)
        {
            TResponse<RegisterResponse> result = new TResponse<RegisterResponse>();
            if (ModelState.IsValid)
            {
                result = await _accountService.RegisterAsync(new RegisterRequest
                {
                    Username = registerInput.Username,
                    Password = registerInput.Password,
                    ConfirmPassword = registerInput.ConfirmPassword,
                    Email = registerInput.Email,
                    Address = registerInput.Address,
                    Phone = registerInput.PhoneNumber,
                    Fullname = registerInput.FullName,
                });
            }
            if (result.StatusCode == 200)
            {
                SaveInfoLogin(result.Data);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("RegisterError", result.Message);
                return View("Register", registerInput);
            }
        }

        private void SaveInfoLogin(LoginResponse loginResponse)
        {
            SetTokenToSession(loginResponse.AccessToken);
            SetInfoToCookie(loginResponse);
        }

        private void SetInfoToCookie(LoginResponse loginResponse)
        {
            CookieOptions cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true,
                Secure = true
            };
            Response.Cookies.Append("UserInfo", JsonConvert.SerializeObject(loginResponse), cookieOptions);
        }

        private void SetTokenToSession(string token)
        {
            HttpContext.Session.SetString("AccessToken", token);
        }

        private string GetTokenFromSession()
        {
            return HttpContext.Session.GetString("AccessToken");
        }
    }
}