using WebSaleRepository.Infrastructures.Enum;

namespace WebSaleRepository.Responses.Accounts
{
    public class GetCurrentAccountResponse
    {
        public string Username { get; set; }

        public long RoleId { get; set; }

        public AccountStatus AccountStatus { get; set; }
    }
}