using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbContext = AMAP_FARM.Data.DbContext;

namespace AMAP_FARM.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly DbContext _context;  // Updated to use DbContext

        // Constructor to inject the DbContext
        public ProductCategoryService(DbContext context)
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

