using System;
using WebSaleRepository.Infrastructures.Enum;

namespace WebSaleRepository.Requests.Accounts
{
    public class GetStatisticAccountStatusRequest
    {
        public AccountStatus AccountStatus { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
