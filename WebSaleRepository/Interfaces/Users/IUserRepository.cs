using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Requests.Users;
using WebSaleRepository.Responses.Users;

namespace WebSaleRepository.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<TResponse<UserResponse>> GetUserByUsernameAsync(string username);

        Task<TResponse<bool>> EditUserByUsernameAsync(UpdateUserRequest request, string username);
    }
}