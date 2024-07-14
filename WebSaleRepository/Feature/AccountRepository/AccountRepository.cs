using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebSaleRepository.DTO.Accounts;
using WebSaleRepository.Helper;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Infrastructures.Enum;
using WebSaleRepository.Interfaces.Accounts;
using WebSaleRepository.Models;
using WebSaleRepository.Persistance;
using WebSaleRepository.Persistance.Entities;
using WebSaleRepository.Requests.Accounts;
using WebSaleRepository.Responses.Accounts;
using WebSaleRepository.Settings;

namespace WebSaleRepository.Feature.AccountRepository
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        private readonly SaleDbContext _dbContext;
        private readonly int timeExpires = 1;

        public AccountRepository(SaleDbContext dbContext, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(httpContextAccessor, configuration)
        {
            _dbContext = dbContext;
        }

        public async Task<TResponse<LoginResponse>> LoginAsync(LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return await Fail<LoginResponse>("Username or password is empty", new { });
            }

            AccountEntity existAccountInfo = await GetAccountAsync(request.Username);

            if (existAccountInfo == null)
            {
                return await Fail<LoginResponse>("Username or password incorrect", new { });
            }

            RoleEntity role = await _dbContext.RoleEntities.FirstOrDefaultAsync(x => x.Id == existAccountInfo.RoleId);
            if (role == null)
            {
                return await Fail<LoginResponse>("Role not found", new { });
            }

            if (!CipherPlantextHelper.Verify(request.Password, existAccountInfo.Password, existAccountInfo.Salt))
            {
                return await Fail<LoginResponse>("Username or password incorrect", new { });
            }
            AccountDTO accountDto = new AccountDTO
            {
                Username = existAccountInfo.Username,
                Password = existAccountInfo.Password,
                Salt = existAccountInfo.Salt,
                RoleId = existAccountInfo.RoleId,
                AccountStatus = existAccountInfo.AccountStatus,
                RoleName = role.Name
            };
            string token = ManagerTokenHelper.GenarateToken(_configuration, accountDto, timeExpires);

            UserEntity userInfo = await GetUserAsync(existAccountInfo.Username);

            LoginResponse result = new LoginResponse
            {
                AccessToken = token,
                Username = existAccountInfo.Username,
                Fullname = userInfo.Fullname,
                Email = userInfo.Email,
                Phone = userInfo.Phone,
                Address = userInfo.Address,
                RoleName = role.Name
            };
            return await OK(result);
        }

        private async Task<AccountEntity> GetAccountAsync(string username)
        {
            return await _dbContext.AccountEntities.FirstOrDefaultAsync(x => x.Username == username);
        }

        private async Task<UserEntity> GetUserAsync(string username)
        {
            return await _dbContext.UserEntities.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<TResponse<RegisterResponse>> RegisterAsync(RegisterRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return await Fail<RegisterResponse>("Username or password is empty", new { });
            }

            AccountEntity existAccountInfo = await GetAccountAsync(request.Username);

            if (existAccountInfo != null)
            {
                return await Fail<RegisterResponse>("Username {0} is exist!", new { existAccountInfo.Username });
            }

            //so, chu thuong , chu hoa, so, ky tu dac biet, do dai tu 6-20
            //Passoword, password
            if (request.Password != request.ConfirmPassword)
            {
                return await Fail<RegisterResponse>("Password confirm incorrect", new { });
            }
            string salt = CipherPlantextHelper.GenerateSalt();

            //encrypt password by salf
            string newPasswordEncrypted = CipherPlantextHelper.Encrypt(request.ConfirmPassword, salt);
            //lan dau tien tao tai khoan
            // b1: tao account
            // b2: tao user
            // b3: tao token
            // b4: luu user va account
            // b5: tra ve token va thong tin user

            //step 1
            AccountEntity newAccountUser = new AccountEntity
            {
                Username = request.Username,
                Password = newPasswordEncrypted,
                Salt = salt,
                RoleId = (long)RoleConfig.User,
                CreateBy = request.Username,
                IsActive = true, // edit after
                CreateDate = DateTime.UtcNow
            };

            //step 2
            UserEntity newUserInfo = new UserEntity
            {
                Fullname = request.Fullname,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                Username = request.Username,
                CreateBy = request.Username,
            };
            _ = _dbContext.AccountEntities.Add(newAccountUser);

            _ = _dbContext.UserEntities.Add(newUserInfo);

            _ = await _dbContext.SaveChangesAsync();

            UserEntity userInfo = await GetUserAsync(newUserInfo.Username);

            AccountDTO accountDto = new AccountDTO
            {
                Username = newAccountUser.Username,
                Password = newAccountUser.Password,
                Salt = newAccountUser.Salt,
                RoleId = newAccountUser.RoleId,
                AccountStatus = newAccountUser.AccountStatus,
                RoleName = nameof(RoleConfig.User)
            };

            string token = ManagerTokenHelper.GenarateToken(_configuration, accountDto, timeExpires);

            AccountEntity accountInfo = await GetAccountAsync(newAccountUser.Username);

            _ = _dbContext.AccountEntities.Update(accountInfo);

            RegisterResponse result = new RegisterResponse
            {
                AccessToken = token,
                Username = accountInfo.Username,
                Fullname = userInfo.Fullname,
                Email = userInfo.Email,
                Phone = userInfo.Phone,
                Address = userInfo.Address,
                RoleName = nameof(RoleConfig.User)
            };
            return await OK(result);
        }

        public async Task<TResponse<GetCurrentUserPagingRespone>> GetCurrentAccountAsync(int pageIndex, int pageSize)
        {
            TokenInfoModel tokenInfo = GetCurrentRoleInfo();

            if (!tokenInfo.IsAdminRole)
            {
                return await Fail<GetCurrentUserPagingRespone>("You do not have permission to access", new { });
            }

            List<UserEntity> usersData = await _dbContext.UserEntities.ToListAsync();

            List<LoginResponse> users = usersData.Select(x => new LoginResponse
            {
                Fullname = x.Fullname,
                Email = x.Email,
                Phone = x.Phone,
                Address = x.Address,
                Username = x.Username,
                RoleName = tokenInfo.TokenInfo.Role,
            }).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            GetCurrentUserPagingRespone result = new GetCurrentUserPagingRespone
            {
                Data = users,
                Total = usersData.Count,
                PageIndex = pageIndex,
                PageSize = users.Count
            };
            return await OK(result);
        }

        // Admin and user
        public async Task<TResponse<UpdateAccountInfoResponse>> UpdateAccountInfo(UpdateAccountInfoRequest request)
        {
            // get account from database
            // exist => get account info and update new info and keep origin info
            // not exist => return error
            // save change to database

            AccountEntity existAccountInfo = await GetAccountAsync(request.Username);

            _ = _dbContext.AccountEntities.Attach(existAccountInfo);

            _dbContext.Entry(existAccountInfo).Property(x => x.AccountStatus).CurrentValue = AccountStatus.Online;

            _ = await _dbContext.SaveChangesAsync();

            if (existAccountInfo == null)
            {
                return await Fail<UpdateAccountInfoResponse>("Account {0} not exist", new { request.Username });
            }

            existAccountInfo.Password = string.IsNullOrEmpty(request.Password) ? existAccountInfo.Password : CipherPlantextHelper.Encrypt(request.Password, existAccountInfo.Salt);

            TokenInfo tokenInfo = ManagerTokenHelper.GetTokenInfo(_httpContextAccessor, _configuration);

            bool isRoleAdmin = tokenInfo.Role == RoleSettings.AdminRole;

            if (!isRoleAdmin)
            {
                existAccountInfo.Password = string.IsNullOrEmpty(request.Password) ? existAccountInfo.Password : CipherPlantextHelper.Encrypt(request.Password, existAccountInfo.Salt);
                existAccountInfo.AccountStatus = request.AccountStatus;
            }
            else
            {
                existAccountInfo.RoleId = request.RoleId > 0 ? request.RoleId : existAccountInfo.RoleId;
                existAccountInfo.Password = string.IsNullOrEmpty(request.Password) ? existAccountInfo.Password : CipherPlantextHelper.Encrypt(request.Password, existAccountInfo.Salt);
                existAccountInfo.AccountStatus = request.AccountStatus;
            }

            _ = _dbContext.AccountEntities.Update(existAccountInfo);

            UpdateAccountInfoResponse result = new UpdateAccountInfoResponse
            {
                Username = existAccountInfo.Username,
                RoleId = existAccountInfo.RoleId,
                AccountStatus = existAccountInfo.AccountStatus
            };

            return await OK(result);
        }

        public async Task<TResponse<List<GetStatisticAccountStattusResponse>>> StatisticAccountStatus(GetStatisticAccountStatusRequest request)
        {
            List<GetStatisticAccountStattusResponse> statisticByAccountByStatus = _dbContext.AccountEntities
                 .Where(acc => acc.UpdateDate > request.FromDate && acc.UpdateDate < request.ToDate && acc.AccountStatus == request.AccountStatus)
                 .GroupBy(acc => new { acc.AccountStatus })
                 .Select(group => new GetStatisticAccountStattusResponse
                 {
                     AccountStatus = group.Key.AccountStatus,
                     TotalAccount = group.Count(),
                 }).ToList();

            return await OK(statisticByAccountByStatus);
        }

        public async Task<TResponse<List<GetCurrentRolesRespone>>> GetCurrentRolesAsync(string input)
        {
            TokenInfoModel tokenInfo = GetCurrentRoleInfo();

            if (!tokenInfo.IsAdminRole)
            {
                return await Fail<List<GetCurrentRolesRespone>>("You do not have permission to access", new { });
            }
            IQueryable<GetCurrentRolesRespone> result = _dbContext.RoleEntities.Select(x => new GetCurrentRolesRespone
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            });

            return !result.Any()
                ? await Fail<List<GetCurrentRolesRespone>>("Do not have any role in databases", new { })
                : await OK(result.ToList());
        }

        public async Task<TResponse<bool>> CreateaRolesAsync(CreateRoleRequest request)
        {
            TokenInfoModel tokenInfo = GetCurrentRoleInfo();

            if (!tokenInfo.IsAdminRole)
            {
                return await Fail<bool>("You do not have permission to access", new { });
            }
            RoleEntity existRole = await _dbContext.RoleEntities.FirstOrDefaultAsync(x => x.Name == request.RoleName);
            if (existRole != null)
            {
                return await Fail<bool>("Role {0} is exist", new { request.RoleName });
            }

            _ = _dbContext.RoleEntities.Add(new RoleEntity
            {
                Name = request.RoleName,
                Description = request.Description
            });
            int result = await _dbContext.SaveChangesAsync();
            return await OK(result > 0);
        }

        public async Task<TResponse<bool>> AssignRolesAsync(AssignRolesRequest request)
        {
            int result = 0;
            TokenInfoModel tokenInfo = GetCurrentRoleInfo();

            if (!tokenInfo.IsAdminRole)
            {
                return await Fail<bool>("You do not have permission to access", new { });
            }

            AccountEntity existAccountInfo = await GetAccountAsync(request.Username);

            if (existAccountInfo == null)
            {
                return await Fail<bool>("Account {0} not exist", new { request.Username });
            }

            RoleEntity existRole = await _dbContext.RoleEntities.FirstOrDefaultAsync(x => x.Id == request.RoleId);

            if (existRole is null)
            {
                return await Fail<bool>("Role not exist");
            }

            existAccountInfo.RoleId = existRole.Id;

            result = await _dbContext.SaveChangesAsync();

            return await OK(result > 0);
        }

        public async Task<TResponse<bool>> UpdateRolesAsync(UpdateRoleRequest request)
        {
            TokenInfoModel tokenInfo = GetCurrentRoleInfo();

            if (!tokenInfo.IsAdminRole)
            {
                return await Fail<bool>("You do not have permission to access", new { });
            }

            RoleEntity existRole = await _dbContext.RoleEntities.FirstOrDefaultAsync(x => x.Name == request.RoleName);

            if (existRole is null)
            {
                return await Fail<bool>("Role not exist");
            }

            existRole.Name = request.RoleName;
            existRole.Description = request.Description;
            _ = _dbContext.RoleEntities.Update(existRole);
            int result = await _dbContext.SaveChangesAsync();
            return await OK(result > 0);
        }

        public async Task<TResponse<bool>> RemoveRolesAsync(long roleId)
        {
            TokenInfoModel tokenInfo = GetCurrentRoleInfo();

            if (!tokenInfo.IsAdminRole)
            {
                return await Fail<bool>("You do not have permission to access", new { });
            }

            RoleEntity existRole = await _dbContext.RoleEntities.FirstOrDefaultAsync(x => x.Id == roleId);

            if (existRole is null)
            {
                return await Fail<bool>("Role not exist");
            }

            _ = _dbContext.RoleEntities.Remove(existRole);

            int result = await _dbContext.SaveChangesAsync();

            return await OK(result > 0);
        }
    }
}