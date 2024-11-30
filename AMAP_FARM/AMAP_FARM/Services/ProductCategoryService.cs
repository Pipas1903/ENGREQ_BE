using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAP_FARM.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly AppDbContext _context;

        public ProductCategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductCategory>> GetAllCategoriesAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.ProductCategories.FindAsync(categoryId);
        }

        public async Task CreateCategoryAsync(ProductCategory category)
        {
            _context.ProductCategories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(ProductCategory category)
        {
            _context.ProductCategories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _context.ProductCategories.FindAsync(categoryId);
            if (category != null)
            {
                _context.ProductCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
