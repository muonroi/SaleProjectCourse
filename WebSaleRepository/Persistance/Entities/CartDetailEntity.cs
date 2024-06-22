using WebSaleRepository.Persistance.Entities.Base;

namespace WebSaleRepository.Persistance.Entities
{
    public class CartDetailEntity : EntityBase
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public ProductEntity Product { get; set; }
        public CartEntity Cart { get; set; }
    }
}
