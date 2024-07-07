using WebSaleAdmin.Infrastructure.Enum;

namespace WebSaleAdmin.Models.Responses.Accounts
{
    public class UpdateAccountInfoResponse
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public long RoleId { get; set; }

        public AccountStatus AccountStatus { get; set; }
    }
}
