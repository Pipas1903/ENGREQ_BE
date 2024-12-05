using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IProductTypeService
    {
        Task<List<ProductType>> GetAllProductTypesAsync();
        Task<ProductType> GetProductTypeByIdAsync(int productTypeId);
        Task CreateProductTypeAsync(ProductType productType);
        Task UpdateProductTypeAsync(ProductType productType);
        Task DeleteProductTypeAsync(int productTypeId);
    }
}
