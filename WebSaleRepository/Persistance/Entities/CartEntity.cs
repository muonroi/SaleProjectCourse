using System.Collections.Generic;
using WebSaleRepository.Persistance.Entities.Base;

namespace WebSaleRepository.Persistance.Entities
{
    public class CartEntity : EntityBase
    {
        public long UserId { get; set; }
        public List<CartDetailEntity> CartDetail { get; set; }
    }
}