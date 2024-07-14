using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebSaleAdmin.Infrastructure.Enum;
using WebSaleAdmin.Models.Base;
using WebSaleAdmin.Models.Requests.Accounts;
using WebSaleAdmin.Models.Responses.Accounts;
using WebSaleAdmin.Models.Views.Accounts;

namespace WebSaleAdmin.Controllers
{
    public partial class AdminController : Controller
    {
        public ActionResult Login()
        {
            return View(new LoginInput());
        }

        public async Task<IActionResult> Logout()
        {
            LoginResponse currentUserInfo = JsonConvert.DeserializeObject<LoginResponse>(Request.Cookies["UserInfo"]);

            _ = await _accountService.UpdateAccountInfo(new UpdateAccountInfoRequest
            {
                Username = currentUserInfo.Username,
                Password = string.Empty,
                AccountStatus = AccountStatus.Offline,
                RoleId = 0
            }, currentUserInfo.AccessToken);

            HttpContext.Session.Remove("AccessToken");

            Response.Cookies.Delete("UserInfo");

            return RedirectToAction("Login");
        }

        [HttpPost]
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
                _ = await _accountService.UpdateAccountInfo(new UpdateAccountInfoRequest
                {
                    Username = loginInput.Username,
                    Password = string.Empty,
                    AccountStatus = AccountStatus.Online,
                    RoleId = 0
                }, result.Data.AccessToken);
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

        [HttpPost]
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

                _ = await _accountService.UpdateAccountInfo(new UpdateAccountInfoRequest
                {
                    Username = registerInput.Username,
                    Password = string.Empty,
                    AccountStatus = AccountStatus.Online,
                    RoleId = 0
                }, result.Data.AccessToken);

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