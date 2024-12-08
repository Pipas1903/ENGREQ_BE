using AMAP_FARM.DTO;
using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductType>> GetAllProductTypesAsync();
        Task<ProductType> GetProductTypeByIdAsync(int id);
        Task<ProductType> CreateProductTypeAsync(ProductTypeCreateDto productTypeCreateDto);
        Task<bool> UpdateProductTypeAsync(int id, ProductType productType);
        Task<bool> DeleteProductTypeAsync(int id);
    }
}
