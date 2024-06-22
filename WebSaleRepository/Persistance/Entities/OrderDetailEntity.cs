using WebSaleRepository.Persistance.Entities.Base;

namespace WebSaleRepository.Persistance.Entities
{
    public class OrderDetailEntity : EntityBase
    {
        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }

        public ProductEntity Product { get; set; }

        public OrderEntity Order { get; set; }
    }
}
