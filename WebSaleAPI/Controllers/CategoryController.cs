using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Interfaces.Categories;
using WebSaleRepository.Requests.Categories;
using WebSaleRepository.Responses.Categories;

namespace WebSaleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        private readonly ICategoryRepository _categoryRepository;

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            TResponse<List<GetCategoryResponse>> result = await _categoryRepository.GetCategoryAsync();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            TResponse<bool> result = await _categoryRepository.AddCategoryAsync(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory([FromRoute] long id)
        {
            TResponse<bool> result = await _categoryRepository.DeleteCategoryAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory([FromRoute] long id, [FromBody] UpdateCategoryRequest request)
        {
            TResponse<bool> result = await _categoryRepository.UpdateCategoryAsync(id, request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] long id)
        {
            TResponse<GetCategoryResponse> result = await _categoryRepository.GetCategoryByIdAsync(id);
            return Ok(result);
        }
    }
}