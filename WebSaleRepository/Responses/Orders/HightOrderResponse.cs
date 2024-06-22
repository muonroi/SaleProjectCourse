using WebSaleRepository.Infrastructures.Enum;

namespace WebSaleRepository.Responses.Orders
{
    public class HightOrderResponse
    {
        public long Quantity { get; set; }
        public OrderType OrderType { get; set; }
    }
}
