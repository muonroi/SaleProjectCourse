using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSaleAdmin.Infrastructure;
using WebSaleAdmin.Interfaces;
using WebSaleAdmin.Models.Base;
using WebSaleAdmin.Models.Requests.Accounts;
using WebSaleAdmin.Models.Requests.Users;
using WebSaleAdmin.Models.Responses.Accounts;
using WebSaleAdmin.Services.Base;

namespace WebSaleAdmin.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(ILoggerFactory logger) : base(logger)
        {
        }

        // Gán vai trò cho người dùng
        public async Task<TResponse<bool>> AssignRolesAsync(AssignRolesRequest request, string accessToken)
        {
            return await SendPatchRequestAsync(EndPointConfig.AssignRole, request, true, accessToken);
        }

        // Tạo vai trò mới
        public async Task<TResponse<bool>> CreateRolesAsync(CreateRoleRequest request, string accessToken)
        {
            return await SendPostRequestAsync<bool, CreateRoleRequest>(EndPointConfig.ManageRole, request, true, accessToken);
        }

        // Lấy danh sách vai trò hiện tại của người dùng
        public async Task<TResponse<List<GetCurrentRolesRespone>>> GetCurrentRolesAsync(string input, string accessToken)
        {
            return await SendGetRequestAsync<List<GetCurrentRolesRespone>>(string.Format(EndPointConfig.RoleList, input), true, accessToken);
        }

        // Đăng nhập
        public async Task<TResponse<LoginResponse>> LoginAsync(LoginRequest request)
        {
            return await SendPostRequestAsync<LoginResponse, LoginRequest>(EndPointConfig.AccountLogin, request);
        }

        public async Task<TResponse<RegisterResponse>> RegisterAsync(RegisterRequest request)
        {
            return await SendPostRequestAsync<RegisterResponse, RegisterRequest>(EndPointConfig.AccountRegister, request);
        }

        // Xóa vai trò của người dùng
        public async Task<TResponse<bool>> RemoveRolesAsync(long roleId, string accessToken)
        {
            return await SendDeleteRequestAsync<bool>(string.Format(EndPointConfig.ManageRole, roleId), true, accessToken);
        }

        // Thống kê trạng thái tài khoản
        public async Task<TResponse<List<GetStatisticAccountStattusResponse>>> StatisticAccountStatus(GetStatisticAccountStatusRequest request, string accessToken)
        {
            return await SendGetRequestAsync<List<GetStatisticAccountStattusResponse>>(string.Format(EndPointConfig.AccountStatistic, request.AccountStatus, request.FromDate, request.ToDate), true, accessToken);
        }

        // Thống kê trạng thái tài khoản hiện tại
        public async Task<TResponse<List<GetStatisticAccountStattusResponse>>> StatisticAccountStatusNow(GetStatisticAccountStatusNowRequest request, string accessToken)
        {
            return await SendGetRequestAsync<List<GetStatisticAccountStattusResponse>>(string.Format(EndPointConfig.AccountStatistic, request.AccountStatus), true, accessToken);
        }

        // Cập nhật thông tin tài khoản
        public async Task<TResponse<bool>> UpdateAccountInfo(UpdateAccountInfoRequest request, string accessToken)
        {
            return await SendPutRequestAsync(EndPointConfig.AccountUpdateInfo, request, true, accessToken);
        }

        // Lấy danh sách tài khoản hiện tại
        public async Task<TResponse<GetCurrentUserPagingRespone>> GetCurrentAccountAsync(string accessToken)
        {
            return await SendGetRequestAsync<GetCurrentUserPagingRespone>(EndPointConfig.AccountList, true, accessToken);
        }

        public async Task<TResponse<bool>> EditCurrentUserAsync(UpdateUserRequest request, string accessToken)
        {
            return await SendPutRequestAsync(EndPointConfig.AccountUpdateInfo, request, true, accessToken);
        }

        public async Task<TResponse<bool>> DeleteCurrentAccountAsync(string username, string accessToken)
        {
            return await SendDeleteRequestAsync<bool>(string.Format(EndPointConfig.DeleteAccount, username), true, accessToken);
        }

        public async Task<TResponse<bool>> LockCurrentAccountAsync(LockAccountRequest request, string currentToken)
        {
            return await SendPatchRequestAsync(EndPointConfig.LockAccount, request, true, currentToken);
        }

        // Cập nhật vai trò của người dùng
        public async Task<TResponse<bool>> UpdateRolesAsync(UpdateRoleRequest request)
        {
            return await SendPutRequestAsync(EndPointConfig.ManageRole, request, true);
        }
    }
}