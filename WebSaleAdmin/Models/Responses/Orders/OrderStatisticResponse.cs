using System;

namespace WebSaleAdmin.Models.Responses.Orders
{
    public class OrderStatisticResponse
    {
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
