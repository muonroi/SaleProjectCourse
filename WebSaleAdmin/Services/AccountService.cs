using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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

        // Gán vai trò cho người dùng
        public async Task<TResponse<bool>> AssignRolesAsync(AssignRolesRequest request)
        {
            throw new NotImplementedException();
        }

        // Tạo vai trò mới
        public async Task<TResponse<bool>> CreateaRolesAsync(CreateRoleRequest request)
        {
            throw new NotImplementedException();
        }

        // Lấy danh sách vai trò hiện tại của người dùng
        public async Task<TResponse<List<GetCurrentRolesRespone>>> GetCurrentRolesAsync(string input)
        {
            throw new NotImplementedException();
        }

        // Đăng nhập
        public async Task<TResponse<LoginResponse>> LoginAsync(LoginRequest request)
        {
            _ = new TResponse<LoginResponse>();
            TResponse<LoginResponse> result;
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
                result = new TResponse<LoginResponse>
                {
                    StatusCode = 500,
                    Message = "Lỗi hệ thống"
                };
            }
            return result;
        }

        // Đăng ký
        public async Task<TResponse<RegisterResponse>> RegisterAsync(RegisterRequest request)
        {
            _ = new TResponse<RegisterResponse>();
            TResponse<RegisterResponse> result;
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                HttpResponseMessage registerResponse = await _httpClient.PostAsync(EndPointConfig.AccountRegister, content);
                string registerResponseContent = await registerResponse.Content.ReadAsStringAsync();
                TResponse<RegisterResponse> response = JsonConvert.DeserializeObject<TResponse<RegisterResponse>>(registerResponseContent);
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
                result = new TResponse<RegisterResponse>
                {
                    StatusCode = 500,
                    Message = "Lỗi hệ thống"
                };
            }
            return result;
        }

        // Xóa vai trò của người dùng
        public async Task<TResponse<bool>> RemoveRolesAsync(long roleId)
        {
            throw new NotImplementedException();
        }

        // Thống kê trạng thái tài khoản
        public async Task<TResponse<List<GetStatisticAccountStattusResponse>>> StatisticAccountStatus(GetStatisticAccountStatusRequest request, string accessToken)
        {
            _ = new TResponse<List<GetStatisticAccountStattusResponse>>();
            TResponse<List<GetStatisticAccountStattusResponse>> result;
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage statisticUserResponse = await _httpClient.GetAsync($"{EndPointConfig.AccountStatistic}?AccountStatus={request.AccountStatus}&FromDate={request.FromDate}&ToDate={request.ToDate}");
                string statisticUserResponseContent = await statisticUserResponse.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TResponse<List<GetStatisticAccountStattusResponse>>>(statisticUserResponseContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                result = new TResponse<List<GetStatisticAccountStattusResponse>>
                {
                    StatusCode = 500,
                    Message = "Lỗi hệ thống"
                };
            }
            return result;
        }

        // Thống kê trạng thái tài khoản hiện tại
        public async Task<TResponse<List<GetStatisticAccountStattusResponse>>> StatisticAccountStatusNow(GetStatisticAccountStatusNowRequest request, string accessToken)
        {
            _ = new TResponse<List<GetStatisticAccountStattusResponse>>();
            TResponse<List<GetStatisticAccountStattusResponse>> result;
            try
            {
                DateTime dateTimeNow = DateTime.UtcNow;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage statisticUserResponse = await _httpClient.GetAsync($"{EndPointConfig.AccountStatistic}?AccountStatus={request.AccountStatus}&FromDate={dateTimeNow.AddHours(-5)}&ToDate={dateTimeNow}"
                    );
                string statisticUserResponseContent = await statisticUserResponse.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TResponse<List<GetStatisticAccountStattusResponse>>>(statisticUserResponseContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                result = new TResponse<List<GetStatisticAccountStattusResponse>>
                {
                    StatusCode = 500,
                    Message = "Lỗi hệ thống"
                };
            }
            return result;
        }

        // Cập nhật thông tin tài khoản
        public async Task<TResponse<UpdateAccountInfoResponse>> UpdateAccountInfo(UpdateAccountInfoRequest request, string accessToken)
        {
            _ = new TResponse<UpdateAccountInfoResponse>();
            TResponse<UpdateAccountInfoResponse> result;
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync(EndPointConfig.AccountUpdateInfo, content);
                string responseContent = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TResponse<UpdateAccountInfoResponse>>(responseContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                result = new TResponse<UpdateAccountInfoResponse>
                {
                    StatusCode = 500,
                    Message = "Lỗi hệ thống"
                };
            }
            return result;
        }

        // Cập nhật vai trò của người dùng
        public async Task<TResponse<bool>> UpdateRolesAsync(UpdateRoleRequest request)
        {
            throw new NotImplementedException();
            //TResponse<bool> result = new TResponse<bool>();
            //try
            //{
            //    StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            //    HttpResponseMessage response = await _httpClient.PutAsync(EndPointConfig.UpdateRole, content);
            //    string responseContent = await response.Content.ReadAsStringAsync();
            //    result = JsonConvert.DeserializeObject<TResponse<bool>>(responseContent);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, ex.Message);
            //    result = new TResponse<bool>
            //    {
            //        StatusCode = 500,
            //        Message = "Lỗi hệ thống"
            //    };
            //}
            //return result;
        }
    }
}