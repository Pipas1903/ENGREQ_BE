using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IProductCategoryService
    {
        // Get all categories asynchronously
        Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync();

        // Create a new category asynchronously
        Task<ProductCategory> CreateProductCategoryAsync(ProductCategory productCategory);
    }
}