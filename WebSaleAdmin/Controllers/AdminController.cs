using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSaleAdmin.Infrastructure.Enum;
using WebSaleAdmin.Interfaces;
using WebSaleAdmin.Models.Base;
using WebSaleAdmin.Models.Requests.Accounts;
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
            return View(userData);
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