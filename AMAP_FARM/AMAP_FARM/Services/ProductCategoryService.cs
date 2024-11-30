using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAP_FARM.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly AppDbContext _context;  // Updated to use DbContext

        // Constructor to inject the DbContext
        public ProductCategoryService(AppDbContext context)
        {
            _context = context;
        }

        // Method to get all product categories from the database
        public async Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        // Method to create a new product category
        public async Task<ProductCategory> CreateProductCategoryAsync(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();
            return productCategory;
        }
    }
}

