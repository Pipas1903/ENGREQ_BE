using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = AMAP_FARM.Data.DbContext;

namespace AMAP_FARM.Services
{
    public class ProductService : IProductService
    {
        private readonly DbContext _context;

        // Constructor to inject the DbContext
        public ProductService(DbContext context)
        {
            _context = context;
        }

        // Method to get all products from the database, including product category information
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.Include(p => p.ProductCategoryId).ToListAsync();
        }

        // Method to create a new product
        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}

