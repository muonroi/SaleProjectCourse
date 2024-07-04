using System.Collections.Generic;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Requests.Categories;
using WebSaleRepository.Responses.Categories;

namespace WebSaleRepository.Interfaces.Categories
{
    public interface ICategoryRepository
    {
        Task<TResponse<List<GetCategoryResponse>>> GetCategoryAsync();

        Task<TResponse<GetCategoryResponse>> GetCategoryByIdAsync(long id);

        Task<TResponse<bool>> AddCategoryAsync(CreateCategoryRequest request);

        Task<TResponse<bool>> UpdateCategoryAsync(long id, UpdateCategoryRequest request);

        Task<TResponse<bool>> DeleteCategoryAsync(long id);
    }
}