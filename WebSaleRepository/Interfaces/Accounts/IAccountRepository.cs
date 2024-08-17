using System.Collections.Generic;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Requests.Accounts;
using WebSaleRepository.Responses.Accounts;

namespace WebSaleRepository.Interfaces.Accounts
{
    public interface IAccountRepository
    {
        Task<TResponse<GetCurrentAccountResponse>> GetFirstOrDefaultAccountAsync(string accountId);

        Task<TResponse<GetCurrentUserPagingRespone>> GetCurrentAccountAsync(string keyword, int pageIndex, int pageSize);

        Task<TResponse<LoginResponse>> LoginAsync(LoginRequest request);

        Task<TResponse<RegisterResponse>> RegisterAsync(RegisterRequest request);

        Task<TResponse<bool>> RemoveAccountAsync(string username);

        Task<TResponse<bool>> UpdateAccountInfo(UpdateAccountInfoRequest request);

        Task<TResponse<List<GetStatisticAccountStattusResponse>>> StatisticAccountStatus(GetStatisticAccountStatusRequest request);

        Task<TResponse<List<GetCurrentRolesRespone>>> GetCurrentRolesAsync(string input);

        Task<TResponse<bool>> CreateaRolesAsync(CreateRoleRequest request);

        Task<TResponse<bool>> AssignRolesAsync(AssignRolesRequest request);

        Task<TResponse<bool>> UpdateRolesAsync(UpdateRoleRequest request);

        Task<TResponse<bool>> RemoveRolesAsync(string roleName);

        Task<TResponse<bool>> LockAccountAsync(string username);
    }
}