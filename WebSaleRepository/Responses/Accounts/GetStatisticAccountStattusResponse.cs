using WebSaleRepository.Infrastructures.Enum;

namespace WebSaleRepository.Responses.Accounts
{
    public class GetStatisticAccountStattusResponse
    {
        public long TotalAccount { get; set; }
        public AccountStatus AccountStatus { get; set; }
    }
}
