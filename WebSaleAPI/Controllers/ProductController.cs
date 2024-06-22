using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Interfaces.Products;
using WebSaleRepository.Requests.Products;
using WebSaleRepository.Responses.Products;

namespace WebSaleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        private readonly IProductRepository _productRepository;

        [HttpGet("paging")]
        public async Task<IActionResult> GetPagingProduct([FromQuery] int pageIndex = 1, int pageSize = 10)
        {
            TResponse<GetProductPagingResponse> result = await _productRepository.GetPagingProductAsync(pageIndex, pageSize);
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }

        [HttpGet("{idNo}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid idNo)
        {
            TResponse<GetProductResponse> result = await _productRepository.GetProductAsync(idNo);
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProduct([FromRoute] long categoryId, [FromQuery] int pageIndex = 1, int pageSize = 10)
        {
            TResponse<GetProductPagingResponse> result = await _productRepository.GetProductByCategoryAsync(categoryId, pageIndex, pageSize);
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            TResponse<bool> result = await _productRepository.AddProductAsync(request);
            return Ok(result);
        }

        [HttpPut("{idNo}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid idNo, [FromBody] EditProductRequest request)
        {
            TResponse<bool> result = await _productRepository.EditProductAsync(idNo, request);
            return Ok(result);
        }

        [HttpDelete("{idNo}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid idNo)
        {
            TResponse<bool> result = await _productRepository.DeleteProductAsync(idNo);
            return Ok(result);
        }
    }
}