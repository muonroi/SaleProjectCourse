using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSaleAdmin.Infrastructure.Enum;
using WebSaleAdmin.Interfaces;
using WebSaleAdmin.Models.Base;
using WebSaleAdmin.Models.Requests.Accounts;
using WebSaleAdmin.Models.Requests.Users;
using WebSaleAdmin.Models.Responses.Accounts;

namespace WebSaleAdmin.Controllers
{
    public partial class AdminController : Controller
    {
        private readonly IAccountService _accountService;

        public AdminController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            string currentToken = GetTokenFromSession();
            string currentUserInfo = Request.Cookies["UserInfo"];
            if (!string.IsNullOrEmpty(currentToken))
            {
                int userOnline = await GetCurrentUserOnline(currentToken);
                ViewData["CurrentTotalUserOnline"] = userOnline;
            }
            return (string.IsNullOrEmpty(currentToken) || string.IsNullOrEmpty(currentUserInfo)) ? RedirectToAction("Login") : (IActionResult)View();
        }

        [HttpGet]
        public async Task<IActionResult> GetListAccount()
        {
            string currentToken = GetTokenFromSession();
            if (string.IsNullOrEmpty(currentToken))
            {
                return RedirectToAction("Login");
            }

            TResponse<GetCurrentUserPagingRespone> result = await _accountService.GetCurrentAccountAsync(currentToken);
            GetCurrentUserPagingRespone userData = result.StatusCode == 200 ? result.Data : new GetCurrentUserPagingRespone();
            Tuple<GetCurrentUserPagingRespone, RegisterRequest> tuple = new Tuple<GetCurrentUserPagingRespone, RegisterRequest>(userData, new RegisterRequest());
            return View(tuple);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] RegisterRequest request)
        {
            string currentToken = GetTokenFromSession();
            if (string.IsNullOrEmpty(currentToken))
            {
                return RedirectToAction("Login");
            }
            if (!ModelState.IsValid)
            {
                string message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                ModelState.AddModelError("CreateAccountError", message);
                return RedirectToAction("GetListAccount");
            }
            TResponse<RegisterResponse> result = await _accountService.RegisterAsync(request);
            if (result.StatusCode != 200)
            {
                ModelState.AddModelError("CreateAccountError", result.Message);
            }
            return RedirectToAction("GetListAccount");
        }

        [HttpPut]
        public async Task<IActionResult> EditAccount([FromBody] UpdateUserRequest request)
        {
            string currentToken = GetTokenFromSession();
            if (string.IsNullOrEmpty(currentToken))
            {
                return RedirectToAction("Login");
            }
            if (!ModelState.IsValid)
            {
                string message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                ModelState.AddModelError("EditCurrentUserError", message);
                return RedirectToAction("GetListAccount");
            }
            TResponse<bool> result = await _accountService.EditCurrentUserAsync(request, currentToken);
            if (result.StatusCode != 200)
            {
                ModelState.AddModelError("EditCurrentUserError", result.Message);
            }
            return RedirectToAction("GetListAccount");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount([FromBody] DeleteAccountRequest request)
        {
            string currentToken = GetTokenFromSession();
            if (string.IsNullOrEmpty(currentToken))
            {
                return RedirectToAction("Login");
            }
            if (!ModelState.IsValid)
            {
                string message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return RedirectToAction("GetListAccount");
            }
            TResponse<bool> result = await _accountService.DeleteCurrentAccountAsync(request.Username, currentToken);
            if (result.StatusCode != 200)
            {
            }
            return RedirectToAction("GetListAccount");
        }

        [HttpPatch]
        public async Task<IActionResult> LockAccount([FromBody] LockAccountRequest request)
        {
            string currentToken = GetTokenFromSession();
            if (string.IsNullOrEmpty(currentToken))
            {
                return RedirectToAction("Login");
            }
            if (!ModelState.IsValid)
            {
                string message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return RedirectToAction("GetListAccount");
            }
            TResponse<bool> result = await _accountService.LockCurrentAccountAsync(request, currentToken);
            if (result.StatusCode != 200)
            {
            }
            return RedirectToAction("GetListAccount");
        }

        private async Task<int> GetCurrentUserOnline(string accessToken)
        {
            TResponse<List<GetStatisticAccountStattusResponse>> result = await _accountService.StatisticAccountStatusNow(new GetStatisticAccountStatusNowRequest
            {
                AccountStatus = AccountStatus.Online
            }, accessToken);

            return result.StatusCode == 200 ? result.Data.Count : 0;
        }
    }
}