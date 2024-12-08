using AMAP_FARM.DTO;
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

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetProductCategoryByIdAsync(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }

        public async Task<ProductCategory> CreateProductCategoryAsync(ProductCategoryCreateDto productCategoryCreateDto)
        {
            var productCategory = new ProductCategory
            {
                Name = productCategoryCreateDto.Name,
                Description = productCategoryCreateDto.Description
            };

            _context.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();

            return productCategory;
        }

        public async Task<bool> UpdateProductCategoryAsync(int id, ProductCategory productCategory)
        {
            var existingProductCategory = await _context.ProductCategories.FindAsync(id);
            if (existingProductCategory == null)
            {
                return false;
            }

            existingProductCategory.Name = productCategory.Name;
            existingProductCategory.Description = productCategory.Description;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProductCategoryAsync(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return false;
            }

            _context.ProductCategories.Remove(productCategory);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<ProductCategory> CreateProductCategoryAsync(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }
    }
}
