using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IProductService
    {
        // Get all products asynchronously
        Task<IEnumerable<Product>> GetAllProductsAsync();

        // Create a new product asynchronously
        Task<Product> CreateProductAsync(Product product);
    }
}

