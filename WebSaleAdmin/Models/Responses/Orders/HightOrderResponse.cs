using WebSaleAdmin.Infrastructure.Enum;

namespace WebSaleAdmin.Models.Responses.Orders
{
    public class HightOrderResponse
    {
        public long Quantity { get; set; }
        public OrderType OrderType { get; set; }
    }
}
