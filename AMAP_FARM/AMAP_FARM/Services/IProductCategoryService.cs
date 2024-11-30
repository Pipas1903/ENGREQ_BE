using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategory>> GetAllCategoriesAsync();
        Task<ProductCategory> GetCategoryByIdAsync(int categoryId);
        Task CreateCategoryAsync(ProductCategory category);
        Task UpdateCategoryAsync(ProductCategory category);
        Task DeleteCategoryAsync(int categoryId);
    }
}