﻿using System;

namespace WebSaleAdmin.Models.Requests.Orders
{
    public class OrderStatisticRequest
    {
        public long ProductId { get; set; }

        public DateTime FromOrderDate { get; set; }

        public DateTime ToOrderDate { get; set; }

    }
}
