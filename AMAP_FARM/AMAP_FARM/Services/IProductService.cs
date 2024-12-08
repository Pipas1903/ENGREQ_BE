using AMAP_FARM.DTO;
using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(ProductCreateDto productDto);
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> UpdateProductAsync(int id, ProductCreateDto productDto);
        Task<bool> DeleteProductAsync(int id);
    }
}
