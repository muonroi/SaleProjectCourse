using System.Collections.Generic;

namespace WebSaleAdmin.Models.Responses.Products
{
    public class GetProductPagingResponse
    {
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public List<GetProductResponse> Data { get; set; }
    }
}
