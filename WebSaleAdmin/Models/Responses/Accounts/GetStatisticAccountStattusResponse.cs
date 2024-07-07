using WebSaleAdmin.Infrastructure.Enum;

namespace WebSaleAdmin.Models.Responses.Accounts
{
    public class GetStatisticAccountStattusResponse
    {
        public long TotalAccount { get; set; }
        public AccountStatus AccountStatus { get; set; }
    }
}