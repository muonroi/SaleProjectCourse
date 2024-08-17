using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebSaleAdmin.Models.Base;

namespace WebSaleAdmin.Services.Base
{
    public abstract class BaseService
    {
        protected ILogger<BaseService> _logger;

        protected static readonly HttpClient _httpClient = new HttpClient();

        protected BaseService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BaseService>();
        }

        protected async Task<TResponse<T>> SendGetRequestAsync<T>(string url, bool isAuthorized = false, string accessToken = "")
        {
            try
            {
                if (isAuthorized)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse<T>>(responseContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new TResponse<T>
                {
                    StatusCode = 500,
                    Message = "Lỗi hệ thống"
                };
            }
        }

        protected async Task<TResponse<TResult>> SendPostRequestAsync<TResult, TRequest>(string url, TRequest contentObject, bool isAuthorized = false, string accessToken = "")
        {
            try
            {
                if (isAuthorized)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                StringContent content = new StringContent(JsonConvert.SerializeObject(contentObject),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse<TResult>>(responseContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new TResponse<TResult>
                {
                    StatusCode = 500,
                    Message = "Lỗi hệ thống"
                };
            }
        }

        protected async Task<TResponse<bool>> SendPutRequestAsync<T>(string url, T contentObject, bool isAuthorized = false, string accessToken = "")
        {
            try
            {
                if (isAuthorized)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                StringContent content = new StringContent(JsonConvert.SerializeObject(contentObject),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse<bool>>(responseContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new TResponse<bool>
                {
                    StatusCode = 500,
                    Message = "Lỗi hệ thống"
                };
            }
        }

        protected async Task<TResponse<bool>> SendDeleteRequestAsync<T>(string url, bool isAuthorized = false, string accessToken = "")
        {
            try
            {
                if (isAuthorized)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                HttpResponseMessage response = await _httpClient.DeleteAsync(url);
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse<bool>>(responseContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new TResponse<bool>
                {
                    StatusCode = 500,
                    Message = "Lỗi hệ thống"
                };
            }
        }

        protected async Task<TResponse<bool>> SendPatchRequestAsync<T>(string url, T contentObject, bool isAuthorized = false, string accessToken = "")
        {
            try
            {
                if (isAuthorized)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                StringContent content = new StringContent(JsonConvert.SerializeObject(contentObject),
                    System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PatchAsync(url, content);
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse<bool>>(responseContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new TResponse<bool>
                {
                    StatusCode = 500,
                    Message = "Lỗi hệ thống"
                };
            }
        }
    }
}