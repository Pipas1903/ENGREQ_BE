using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
    }
}

