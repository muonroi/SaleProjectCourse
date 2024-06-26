﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Requests.Accounts;
using WebSaleRepository.Responses.Accounts;

namespace WebSaleRepository.Interfaces.Accounts
{
    public interface IAccountRepository
    {
        Task<TResponse<GetCurrentUserPagingRespone>> GetCurrentAccountAsync(int pageIndex, int pageSize);
        Task<TResponse<LoginResponse>> LoginAsync(LoginRequest request);
        Task<TResponse<RegisterResponse>> RegisterAsync(RegisterRequest request);
        Task<TResponse<UpdateAccountInfoResponse>> UpdateAccountInfo(UpdateAccountInfoRequest request);
        Task<TResponse<List<GetStatisticAccountStattusResponse>>> StatisticAccountStatus(GetStatisticAccountStatusRequest request);
    }
}
