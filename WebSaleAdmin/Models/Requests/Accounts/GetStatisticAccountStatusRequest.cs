using System;
using WebSaleAdmin.Infrastructure.Enum;

namespace WebSaleAdmin.Models.Requests.Accounts
{
    public class GetStatisticAccountStatusRequest
    {
        public AccountStatus AccountStatus { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
