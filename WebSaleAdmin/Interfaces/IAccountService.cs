using System.Collections.Generic;
using System.Threading.Tasks;
using WebSaleAdmin.Models.Base;
using WebSaleAdmin.Models.Requests.Accounts;
using WebSaleAdmin.Models.Requests.Users;
using WebSaleAdmin.Models.Responses.Accounts;

namespace WebSaleAdmin.Interfaces
{
    public interface IAccountService
    {
        Task<TResponse<LoginResponse>> LoginAsync(LoginRequest request);

        Task<TResponse<RegisterResponse>> RegisterAsync(RegisterRequest request);

        Task<TResponse<bool>> UpdateAccountInfo(UpdateAccountInfoRequest request, string accessToken);

        Task<TResponse<List<GetStatisticAccountStattusResponse>>> StatisticAccountStatus(GetStatisticAccountStatusRequest request, string accessToken);

        Task<TResponse<List<GetStatisticAccountStattusResponse>>> StatisticAccountStatusNow(GetStatisticAccountStatusNowRequest request, string accessToken);

        Task<TResponse<List<GetCurrentRolesRespone>>> GetCurrentRolesAsync(string input, string accessToken);

        Task<TResponse<bool>> CreateRolesAsync(CreateRoleRequest request, string accessToken);

        Task<TResponse<bool>> AssignRolesAsync(AssignRolesRequest request, string accessToken);

        Task<TResponse<bool>> UpdateRolesAsync(UpdateRoleRequest request);

        Task<TResponse<bool>> RemoveRolesAsync(long roleId, string accessToken);

        Task<TResponse<GetCurrentUserPagingRespone>> GetCurrentAccountAsync(string accessToken);

        Task<TResponse<bool>> EditCurrentUserAsync(UpdateUserRequest request, string accessToken);

        Task<TResponse<bool>> DeleteCurrentAccountAsync(string username, string currentToken);

        Task<TResponse<bool>> LockCurrentAccountAsync(LockAccountRequest request, string currentToken);
    }
}