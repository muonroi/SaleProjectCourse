using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebSaleRepository.Infrastructures.Enum;
using WebSaleRepository.Persistance.Entities.Base;

namespace WebSaleRepository.Persistance.Entities
{
    public class OrderEntity : EntityBase
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public OrderType OrderType { get; set; }

        public List<OrderDetailEntity> OrderDetailEntities { get; set; }

    }
}