﻿namespace WebSaleAdmin.Models.Requests.Products
{
    public class CreateProductRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public double Size { get; set; }

        public string Color { get; set; }

        public string Image { get; set; }

        public int StarNumber { get; set; }

        public long CategoryId { get; set; }
    }
}