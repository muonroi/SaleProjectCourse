using System.Collections.Generic;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Requests.Orders;
using WebSaleRepository.Responses.Orders;

namespace WebSaleRepository.Interfaces.Orders
{
    public interface IOrderRepository
    {
        Task<TResponse<List<OrderStatisticResponse>>> GetOrderStatisticsByDateAsync(OrderStatisticRequest request);
        Task<TResponse<List<HightOrderResponse>>> GetHightOrderAsync(HightOrderResquest request);
    }
}
