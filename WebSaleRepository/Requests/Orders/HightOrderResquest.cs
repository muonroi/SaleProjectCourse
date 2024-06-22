using System;
using WebSaleRepository.Infrastructures.Enum;

namespace WebSaleRepository.Requests.Orders
{
    public class HightOrderResquest
    {
        public OrderType OrderType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

    }
}
