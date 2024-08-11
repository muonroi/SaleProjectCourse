using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Interfaces.Accounts;
using WebSaleRepository.Interfaces.Users;
using WebSaleRepository.Persistance;
using WebSaleRepository.Persistance.Entities;
using WebSaleRepository.Requests.Users;
using WebSaleRepository.Responses.Users;

namespace WebSaleRepository.Feature.UserRepository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly SaleDbContext _dbContext;
        private readonly IAccountRepository _accountRepository;

        public UserRepository(SaleDbContext dbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IAccountRepository accountRepository) : base(httpContextAccessor, configuration)
        {
            _dbContext = dbContext;
            _accountRepository = accountRepository;
        }

        public async Task<TResponse<bool>> EditUserByUsernameAsync(UpdateUserRequest request, string username)
        {
            UserEntity existUser = _dbContext.UserEntities.FirstOrDefault(x => x.Username == username);

            if (existUser == null)
            {
                return await Fail<bool>("User {0} not exist", new { username });
            }

            existUser.Fullname = request.Fullname;
            existUser.Email = request.Email;
            existUser.Phone = request.Phone;
            existUser.Address = request.Address;
            _ = _dbContext.UserEntities.Update(existUser);
            _ = await _dbContext.SaveChangesAsync();
            return await OK(true);
        }

        public async Task<TResponse<UserResponse>> GetUserByUsernameAsync(string username)
        {
            UserEntity userInfo = await _dbContext.UserEntities.AsQueryable().FirstOrDefaultAsync(x => x.Username == username);
            if (userInfo == null)
            {
                return await Fail<UserResponse>("User not found");
            }
            TResponse<Responses.Accounts.GetCurrentAccountResponse> existAccountInfo = await _accountRepository.GetFirstOrDefaultAccountAsync(username);
            RoleEntity role = await _dbContext.RoleEntities.FirstOrDefaultAsync(x => x.Id == existAccountInfo.Data.RoleId);
            return role == null
                ? await Fail<UserResponse>("Role not found", new { })
                : await OK(new UserResponse
                {
                    Username = userInfo.Username,
                    Email = userInfo.Email,
                    Fullname = userInfo.Fullname,
                    Address = userInfo.Address,
                    Phone = userInfo.Phone,
                    RoleId = role.Id
                });
        }
    }
}