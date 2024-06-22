using WebSaleRepository.Infrastructures.Enum;

namespace WebSaleRepository.Requests.Accounts
{
    public class UpdateAccountInfoRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public long RoleId { get; set; }

        public AccountStatus AccountStatus { get; set; }
    }
}
