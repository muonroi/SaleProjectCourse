using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Interfaces.Orders;
using WebSaleRepository.Persistance;
using WebSaleRepository.Requests.Orders;
using WebSaleRepository.Responses.Orders;

namespace WebSaleRepository.Feature.OrderRepository
{
    internal class OrderRepository : BaseRepository, IOrderRepository
    {
        private readonly SaleDbContext _dbContext;
        public OrderRepository(SaleDbContext saleDbContext)
        {
            _dbContext = saleDbContext;
        }

        public async Task<TResponse<List<OrderStatisticResponse>>> GetOrderStatisticsByDateAsync(OrderStatisticRequest request)
        {
            List<OrderStatisticResponse> statisticResult = _dbContext.OrderDetailEntities
                 .Where(od => od.Order.CreateDate > request.FromOrderDate && od.Order.CreateDate < request.ToOrderDate && od.ProductId == request.ProductId)
                 .GroupBy(od => new { od.Order.Id, od.ProductId, od.Order.CreateDate })
                 .Select(group => new OrderStatisticResponse
                 {
                     OrderId = group.Key.Id,
                     OrderDate = group.Key.CreateDate,
                     ProductId = group.Key.ProductId,
                     Quantity = group.Sum(od => od.Quantity),
                     ProductName = group.FirstOrDefault().Product.Name,
                     Price = group.Sum(od => od.Quantity * od.Product.Price)
                 }).ToList();

            return await OK(statisticResult);
        }

        public async Task<TResponse<List<HightOrderResponse>>> GetHightOrderAsync(HightOrderResquest request)
        {
            List<HightOrderResponse> statisticByOrderType = _dbContext.OrderEntities
                 .Where(od => od.CreateDate > request.FromDate && od.CreateDate < request.ToDate && od.OrderType == request.OrderType)
                 .GroupBy(od => new { od.OrderType })
                 .Select(group => new HightOrderResponse
                 {
                     OrderType = group.Key.OrderType,
                     Quantity = group.Count(),
                 }).ToList();
            return await OK(statisticByOrderType);
        }
    }
}
