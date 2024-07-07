using System;
using WebSaleAdmin.Infrastructure.Enum;

namespace WebSaleAdmin.Models.Requests.Orders
{
    public class HightOrderResquest
    {
        public OrderType OrderType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

    }
}
