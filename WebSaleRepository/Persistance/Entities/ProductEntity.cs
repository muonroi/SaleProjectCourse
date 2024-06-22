using System.Collections.Generic;
using WebSaleRepository.Persistance.Entities.Base;

namespace WebSaleRepository.Persistance.Entities
{
    public class ProductEntity : EntityBase
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

        public CategoryEntity Category { get; set; }

        public List<OrderDetailEntity> OrderDetailEntities { get; set; }

        public List<CartDetailEntity> CartDetail { get; set; }

    }
}