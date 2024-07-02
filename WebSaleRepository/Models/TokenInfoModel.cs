using WebSaleRepository.Responses.Accounts;

namespace WebSaleRepository.Models
{
    public class TokenInfoModel
    {
        public bool IsAdminRole { get; set; }
        public TokenInfo TokenInfo { get; set; }
    }
}