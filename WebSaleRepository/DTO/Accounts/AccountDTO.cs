using WebSaleRepository.Infrastructures.Enum;

namespace WebSaleRepository.DTO.Accounts
{
    public class AccountDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public long RoleId { get; set; }

        public AccountStatus AccountStatus { get; set; }

        public string RoleName { get; set; }
    }
}