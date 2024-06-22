using System;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Requests.Products;
using WebSaleRepository.Responses.Products;

namespace WebSaleRepository.Interfaces.Products
{
    //Nhap thong tin san pham can them
    public interface IProductRepository
    {
        Task<TResponse<GetProductResponse>> GetProductAsync(Guid idNo);

        Task<TResponse<bool>> AddProductAsync(CreateProductRequest request);

        Task<TResponse<bool>> EditProductAsync(Guid idNo, EditProductRequest request);

        Task<TResponse<bool>> DeleteProductAsync(Guid idNo);

        Task<TResponse<GetProductPagingResponse>> GetPagingProductAsync(int pageIndex, int pageSize);

        Task<TResponse<GetProductPagingResponse>> GetProductByCategoryAsync(long categoryId, int pageIndex, int pageSize);
    }
}