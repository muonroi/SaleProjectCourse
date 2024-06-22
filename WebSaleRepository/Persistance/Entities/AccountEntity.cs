using WebSaleRepository.Infrastructures.Enum;
using WebSaleRepository.Persistance.Entities.Base;

namespace WebSaleRepository.Persistance.Entities
{
    public class AccountEntity : EntityBase
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public long RoleId { get; set; }

        public AccountStatus AccountStatus { get; set; }

        public RoleEntity RoleEntity { get; set; }

        public UserEntity UserEntity { get; set; }
    }
}