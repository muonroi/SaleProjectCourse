using System.Collections.Generic;
using WebSaleRepository.Persistance.Entities.Base;

namespace WebSaleRepository.Persistance.Entities
{
    public class CategoryEntity : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<ProductEntity> Products { get; set; }
    }
}