using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Interfaces.Orders;
using WebSaleRepository.Requests.Orders;
using WebSaleRepository.Responses.Orders;

namespace WebSaleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatisticOrder([FromQuery] OrderStatisticRequest request)
        {
            TResponse<List<OrderStatisticResponse>> response = await _orderRepository.GetOrderStatisticsByDateAsync(request);
            return Ok(response);
        }

        [HttpGet("type")]
        public async Task<IActionResult> GetHightOrderByOrderType([FromQuery] HightOrderResquest request)
        {
            TResponse<List<HightOrderResponse>> response = await _orderRepository.GetHightOrderAsync(request);
            return Ok(response);
        }
    }
}
