using System.Collections.Generic;
using WebSaleRepository.Persistance.Entities.Base;

namespace WebSaleRepository.Persistance.Entities
{
    public class RoleEntity : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<AccountEntity> Account { get; set; }
    }
}