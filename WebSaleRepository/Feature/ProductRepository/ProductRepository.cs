using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Infrastructures.Verify.ProductsVerify;
using WebSaleRepository.Interfaces.Products;
using WebSaleRepository.Persistance;
using WebSaleRepository.Persistance.Entities;
using WebSaleRepository.Requests.Products;
using WebSaleRepository.Responses.Products;

namespace WebSaleRepository.Feature.ProductRepository
{
    //transient, scoped, singleton
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly SaleDbContext _dbContext;

        public ProductRepository(SaleDbContext dbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpContextAccessor, configuration)
        {
            _dbContext = dbContext;
        }

        public async Task<TResponse<bool>> AddProductAsync(CreateProductRequest request)
        {
            bool isVeryfied = ProductVerifyRequest.VerifyCreateProductRequest(request);
            if (isVeryfied == false)
            {
                return await Fail<bool>("Request is invalid", new { });
            }

            CategoryEntity categoryResult = _dbContext.CategoryEntities.Find(request.CategoryId);
            if (categoryResult == null)
            {
                return await Fail<bool>("Category {0} not found", new { request.CategoryId });
            }

            _ = _dbContext.ProductEntities.Add(new ProductEntity
            {
                IdNo = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                Size = request.Size,
                Color = request.Color,
                Image = request.Image,
                StarNumber = request.StarNumber,
                CategoryId = categoryResult.Id
            });

            _ = await _dbContext.SaveChangesAsync();

            return await OK(true);
        }

        public async Task<TResponse<bool>> DeleteProductAsync(Guid idNo)
        {
            ProductEntity productEntity = await _dbContext.ProductEntities.FirstOrDefaultAsync(x => x.IdNo == idNo);

            if (productEntity == null)
            {
                return await Fail<bool>("Product {0} not found", new { idNo });
            }

            productEntity.IsDelete = true;
            productEntity.DeletedDate = DateTime.UtcNow;
            _ = _dbContext.ProductEntities.Update(productEntity);
            _ = await _dbContext.SaveChangesAsync();
            return await OK(true);
        }

        public async Task<TResponse<bool>> EditProductAsync(Guid idNo, EditProductRequest request)
        {
            ProductEntity productEntity = await _dbContext.ProductEntities.FirstOrDefaultAsync(x => x.IdNo == idNo);

            if (productEntity == null)
            {
                return await Fail<bool>("Product {0} not found", new { idNo });
            }

            ProductEntity productEntityUpdate = new ProductEntity
            {
                IdNo = productEntity.IdNo,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                Size = request.Size,
                Color = request.Color,
                Image = request.Image,
                StarNumber = request.StarNumber,
                CategoryId = request.CategoryId
            };

            productEntity.UpdateDate = DateTime.UtcNow;

            _ = _dbContext.ProductEntities.Update(productEntityUpdate);

            _ = await _dbContext.SaveChangesAsync();

            return await OK(true);
        }

        public async Task<TResponse<GetProductPagingResponse>> GetPagingProductAsync(int pageIndex, int pageSize)
        {
            List<ProductEntity> productEntity = await _dbContext.ProductEntities.Where(x => x.IsDelete == false).ToListAsync();
            List<GetProductResponse> productData = productEntity.Select(x => new GetProductResponse
            {
                IdNo = x.IdNo,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                Size = x.Size,
                Color = x.Color,
                Image = x.Image,
                StarNumber = x.StarNumber,
                CategoryId = x.CategoryId
            }).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            GetProductPagingResponse result = new GetProductPagingResponse
            {
                Total = productEntity.Count,
                PageSize = productData.Count,
                PageIndex = pageIndex,
                Data = productData
            };
            return result == null
                ? await Fail<GetProductPagingResponse>("Product not found", new { })
                : await OK(result);
        }

        public async Task<TResponse<GetProductResponse>> GetProductAsync(Guid idNo)
        {
            ProductEntity productEntity = await _dbContext.ProductEntities.FirstOrDefaultAsync(x => x.IdNo == idNo && x.IsDelete == false);
            return productEntity == null
                ? await Fail<GetProductResponse>("Product not found", new { })
                : await OK(new GetProductResponse
                {
                    IdNo = productEntity.IdNo,
                    Name = productEntity.Name,
                    Description = productEntity.Description,
                    Price = productEntity.Price,
                    Stock = productEntity.Stock,
                    Size = productEntity.Size,
                    Color = productEntity.Color,
                    Image = productEntity.Image,
                    StarNumber = productEntity.StarNumber,
                    CategoryId = productEntity.CategoryId
                });
        }

        public async Task<TResponse<GetProductPagingResponse>> GetProductByCategoryAsync(long categoryId, int pageIndex, int pageSize)
        {
            List<ProductEntity> productEntity = await _dbContext.ProductEntities.Where(x => x.IsDelete == false && x.CategoryId == categoryId).ToListAsync();
            List<GetProductResponse> productData = productEntity.Select(x => new GetProductResponse
            {
                IdNo = x.IdNo,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                Size = x.Size,
                Color = x.Color,
                Image = x.Image,
                StarNumber = x.StarNumber,
                CategoryId = x.CategoryId
            }).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            GetProductPagingResponse result = new GetProductPagingResponse
            {
                Total = productEntity.Count,
                PageIndex = pageIndex,
                PageSize = productData.Count,
                Data = productData
            };
            return result == null
                ? await Fail<GetProductPagingResponse>("Product not found", new { })
                : await OK(result);
        }
    }
}