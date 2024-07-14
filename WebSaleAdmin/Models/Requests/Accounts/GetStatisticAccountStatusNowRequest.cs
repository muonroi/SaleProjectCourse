using WebSaleAdmin.Infrastructure.Enum;

namespace WebSaleAdmin.Models.Requests.Accounts
{
    public class GetStatisticAccountStatusNowRequest
    {
        public AccountStatus AccountStatus { get; set; }
    }
}