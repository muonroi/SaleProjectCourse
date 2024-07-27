using System.Collections.Generic;
using System.Threading.Tasks;
using WebSaleAdmin.Models.Base;
using WebSaleAdmin.Models.Requests.Accounts;
using WebSaleAdmin.Models.Responses.Accounts;

namespace WebSaleAdmin.Interfaces
{
    public interface IAccountService
    {
        Task<TResponse<LoginResponse>> LoginAsync(LoginRequest request);

        Task<TResponse<RegisterResponse>> RegisterAsync(RegisterRequest request);

        Task<TResponse<UpdateAccountInfoResponse>> UpdateAccountInfo(UpdateAccountInfoRequest request, string accessToken);

        Task<TResponse<List<GetStatisticAccountStattusResponse>>> StatisticAccountStatus(GetStatisticAccountStatusRequest request, string accessToken);

        Task<TResponse<List<GetStatisticAccountStattusResponse>>> StatisticAccountStatusNow(GetStatisticAccountStatusNowRequest request, string accessToken);

        Task<TResponse<List<GetCurrentRolesRespone>>> GetCurrentRolesAsync(string input);

        Task<TResponse<bool>> CreateaRolesAsync(CreateRoleRequest request);

        Task<TResponse<bool>> AssignRolesAsync(AssignRolesRequest request);

        Task<TResponse<bool>> UpdateRolesAsync(UpdateRoleRequest request);

        Task<TResponse<bool>> RemoveRolesAsync(long roleId);

        Task<TResponse<GetCurrentUserPagingRespone>> GetCurrentAccountAsync(string accessToken);
    }
}