using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebSaleAdmin.Infrastructure;
using WebSaleAdmin.Interfaces;
using WebSaleAdmin.Models.Base;
using WebSaleAdmin.Models.Requests.Accounts;
using WebSaleAdmin.Models.Responses.Accounts;
using WebSaleAdmin.Services.Base;

namespace WebSaleAdmin.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(ILoggerFactory logger) : base(logger)
        {
        }

        public Task<TResponse<bool>> AssignRolesAsync(AssignRolesRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResponse<bool>> CreateaRolesAsync(CreateRoleRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResponse<List<GetCurrentRolesRespone>>> GetCurrentRolesAsync(string input)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TResponse<LoginResponse>> LoginAsync(LoginRequest request)
        {
            TResponse<LoginResponse> result = new TResponse<LoginResponse>();
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                HttpResponseMessage loginResponse = await _httpClient.PostAsync(EndPointConfig.AccountLogin, content);
                string loginResponseContent = await loginResponse.Content.ReadAsStringAsync();
                TResponse<LoginResponse> response = JsonConvert.DeserializeObject<TResponse<LoginResponse>>(loginResponseContent);
                result = response.StatusCode != 200
                    ? new TResponse<LoginResponse>
                    {
                        StatusCode = response.StatusCode,
                        Message = response.Message
                    }
                    : response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }

        public async Task<TResponse<RegisterResponse>> RegisterAsync(RegisterRequest request)
        {
            TResponse<RegisterResponse> result = new TResponse<RegisterResponse>();
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                HttpResponseMessage loginResponse = await _httpClient.PostAsync(EndPointConfig.AccountRegister, content);
                string loginResponseContent = await loginResponse.Content.ReadAsStringAsync();
                TResponse<RegisterResponse> response = JsonConvert.DeserializeObject<TResponse<RegisterResponse>>(loginResponseContent);
                result = response.StatusCode != 200
                    ? new TResponse<RegisterResponse>
                    {
                        StatusCode = response.StatusCode,
                        Message = response.Message
                    }
                    : response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }

        public Task<TResponse<bool>> RemoveRolesAsync(long roleId)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResponse<List<GetStatisticAccountStattusResponse>>> StatisticAccountStatus(GetStatisticAccountStatusRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResponse<UpdateAccountInfoResponse>> UpdateAccountInfo(UpdateAccountInfoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResponse<bool>> UpdateRolesAsync(UpdateRoleRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}