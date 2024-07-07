using System.Collections.Generic;

namespace WebSaleAdmin.Models.Responses.Accounts
{
    public class GetCurrentUserPagingRespone
    {
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public List<LoginResponse> Data { get; set; }
    }
}
