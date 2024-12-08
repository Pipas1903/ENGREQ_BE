using AMAP_FARM.DTO;
using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync();
        Task<ProductCategory> GetProductCategoryByIdAsync(int id);
        Task<ProductCategory> CreateProductCategoryAsync(ProductCategoryCreateDto productCategoryCreateDto);
        Task<bool> UpdateProductCategoryAsync(int id, ProductCategory productCategory);
        Task<bool> DeleteProductCategoryAsync(int id);
    }
}
