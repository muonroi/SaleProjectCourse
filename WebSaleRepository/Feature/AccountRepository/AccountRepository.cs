﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSaleRepository.Helper;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Infrastructures.Enum;
using WebSaleRepository.Interfaces.Accounts;
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
        private readonly IConfiguration _configuration;
        private readonly int timeExpires = 1;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountRepository(SaleDbContext dbContext, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
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

            if (!CipherPlantextHelper.Verify(request.Password, existAccountInfo.Password, existAccountInfo.Salt))
            {
                return await Fail<LoginResponse>("Username or password incorrect", new { });
            }

            string token = ManagerTokenHelper.GenarateToken(_configuration, existAccountInfo, timeExpires);

            UserEntity userInfo = await GetUserAsync(existAccountInfo.Username);

            LoginResponse result = new LoginResponse
            {
                AccessToken = token,
                Username = existAccountInfo.Username,
                Fullname = userInfo.Fullname,
                Email = userInfo.Email,
                Phone = userInfo.Phone,
                Address = userInfo.Address,
                RoleId = existAccountInfo.RoleId,
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

            string token = ManagerTokenHelper.GenarateToken(_configuration, newAccountUser, timeExpires);

            UserEntity userInfo = await GetUserAsync(newAccountUser.Username);

            AccountEntity accountInfo = await GetAccountAsync(newAccountUser.Username);

            RegisterResponse result = new RegisterResponse
            {
                AccessToken = token,
                Username = accountInfo.Username,
                Fullname = userInfo.Fullname,
                Email = userInfo.Email,
                Phone = userInfo.Phone,
                Address = userInfo.Address,
                RoleId = accountInfo.RoleId,
            };
            return await OK(result);
        }

        public async Task<TResponse<GetCurrentUserPagingRespone>> GetCurrentAccountAsync(int pageIndex, int pageSize)
        {
            TokenInfo tokenInfo = ManagerTokenHelper.GetTokenInfo(_httpContextAccessor, _configuration);

            bool isRoleAdmin = tokenInfo.Role == RoleSettings.AdminRole;
            if (!isRoleAdmin)
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
                RoleId = tokenInfo.Role,
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

            if (existAccountInfo == null)
            {
                return await Fail<UpdateAccountInfoResponse>("Account {0} not exist", new { request.Username });
            }

            existAccountInfo.Password = request.Password;

            TokenInfo tokenInfo = ManagerTokenHelper.GetTokenInfo(_httpContextAccessor, _configuration);

            bool isRoleAdmin = tokenInfo.Role == RoleSettings.AdminRole;

            if (!isRoleAdmin)
            {
                existAccountInfo.Password = request.Password;
            }

            else
            {
                existAccountInfo.RoleId = request.RoleId;
                existAccountInfo.AccountStatus = request.AccountStatus;
            }

            _ = _dbContext.AccountEntities.Update(existAccountInfo);

            _ = await _dbContext.SaveChangesAsync();

            UpdateAccountInfoResponse result = new UpdateAccountInfoResponse
            {
                Username = existAccountInfo.Username,
                Password = existAccountInfo.Password,
                RoleId = existAccountInfo.RoleId,
                AccountStatus = existAccountInfo.AccountStatus
            };

            return await OK(result);
        }

        public async Task<TResponse<List<GetStatisticAccountStattusResponse>>> StatisticAccountStatus(GetStatisticAccountStatusRequest request)
        {
            List<GetStatisticAccountStattusResponse> statisticByAccountByStatus = _dbContext.AccountEntities
                 .Where(acc => acc.CreateDate > request.FromDate && acc.CreateDate < request.ToDate && acc.AccountStatus == request.AccountStatus)
                 .GroupBy(acc => new { acc.AccountStatus })
                 .Select(group => new GetStatisticAccountStattusResponse
                 {
                     AccountStatus = group.Key.AccountStatus,
                     TotalAccount = group.Count(),
                 }).ToList();

            return await OK(statisticByAccountByStatus);
        }
    }
}
