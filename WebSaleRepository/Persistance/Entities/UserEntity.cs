using System.ComponentModel.DataAnnotations;
using WebSaleRepository.Persistance.Entities.Base;

namespace WebSaleRepository.Persistance.Entities
{
    public class UserEntity : EntityBase
    {
        public string Fullname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Username { get; set; }

        public AccountEntity AccountEntity { get; set; }
    }
}