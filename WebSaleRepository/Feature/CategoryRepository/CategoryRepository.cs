using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSaleRepository.Helper;
using WebSaleRepository.Infrastructures.Base;
using WebSaleRepository.Interfaces.Categories;
using WebSaleRepository.Models;
using WebSaleRepository.Persistance;
using WebSaleRepository.Persistance.Entities;
using WebSaleRepository.Requests.Categories;
using WebSaleRepository.Responses.Categories;

namespace WebSaleRepository.Feature.CategoryRepository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        private readonly SaleDbContext _dbContext;

        public CategoryRepository(SaleDbContext dbContext, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpContextAccessor, configuration)
        {
            _dbContext = dbContext;
        }

        public async Task<TResponse<bool>> AddCategoryAsync(CreateCategoryRequest request)
        {
            int result = 0;
            // sure text is same type or same format
            TokenInfoModel tokenInfo = GetCurrentRoleInfo();

            if (!tokenInfo.IsAdminRole)
            {
                return await Fail<bool>("You do not have permission to access", new { });
            }

            if (string.IsNullOrEmpty(request.Name))
            {
                return await Fail<bool>("Name is required", new { });
            }

            CategoryEntity category = await _dbContext.CategoryEntities.FirstOrDefaultAsync(x => x.Name.ToLower() == request.Name.ToLower());

            if (category == null)
            {
                string categoryNameFormat = StringHelper.CapitalizeAfterSpaceOrFirstLetter(request.Name);

                _ = await _dbContext.CategoryEntities.AddAsync(new CategoryEntity
                {
                    Name = categoryNameFormat,
                    Description = request.Description
                });
            }
            result = await _dbContext.SaveChangesAsync();
            return await OK(result > 0);
        }

        public async Task<TResponse<bool>> DeleteCategoryAsync(long id)
        {
            // sure text is same type or same format
            TokenInfoModel tokenInfo = GetCurrentRoleInfo();

            if (!tokenInfo.IsAdminRole)
            {
                return await Fail<bool>("You do not have permission to access", new { });
            }
            CategoryEntity category = await _dbContext.CategoryEntities.FindAsync(id);
            if (category == null)
            {
                return await Fail<bool>("Category not found", new { });
            }
            _ = _dbContext.CategoryEntities.Remove(category);
            int result = await _dbContext.SaveChangesAsync();
            return await OK(result > 0);
        }

        public async Task<TResponse<List<GetCategoryResponse>>> GetCategoryAsync()
        {
            IQueryable<CategoryEntity> category = _dbContext.CategoryEntities.Select(x => x);
            if (category == null || category.Count() == 0)
            {
                return await Fail<List<GetCategoryResponse>>("Category not found", new { });
            }
            List<GetCategoryResponse> result = category.Select(x => new GetCategoryResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();

            return await OK(result);
        }

        public async Task<TResponse<GetCategoryResponse>> GetCategoryByIdAsync(long id)
        {
            CategoryEntity category = await _dbContext.CategoryEntities.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return await Fail<GetCategoryResponse>("Category not found", new { });
            }
            GetCategoryResponse result = new GetCategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return await OK(result);
        }

        public async Task<TResponse<bool>> UpdateCategoryAsync(long id, UpdateCategoryRequest request)
        {
            CategoryEntity category = await _dbContext.CategoryEntities.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return await Fail<bool>("Category not found", new { });
            }
            category.Name = request.Name;
            category.Description = request.Description;
            category.UpdateDate = DateTime.UtcNow;
            _ = _dbContext.CategoryEntities.Update(category);
            int result = await _dbContext.SaveChangesAsync();
            return await OK(result > 0);
        }
    }
}