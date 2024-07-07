using WebSaleAdmin.Models.Requests.Products;

namespace WebSaleAdmin.Infrastructure.Verify.ProductsVerify
{
    public static class ProductVerifyRequest
    {
        public static bool VerifyCreateProductRequest(CreateProductRequest request)
        {
            return !string.IsNullOrEmpty(request.Name) && !string.IsNullOrEmpty(request.Description) && request.Price > 0 && request.Stock > 0 && request.Size > 0 && !string.IsNullOrEmpty(request.Color) && !string.IsNullOrEmpty(request.Image) && request.StarNumber > 0 && request.CategoryId > 0;
        }
    }
}