using AMAP_FARM.DTO;
using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAP_FARM.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly AppDbContext _context;

        public ProductTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int id)
        {
            return await _context.ProductTypes.FindAsync(id);
        }

        public async Task<ProductType> CreateProductTypeAsync(ProductTypeCreateDto productTypeCreateDto)
        {
            var productType = new ProductType
            {
                Name = productTypeCreateDto.Name
            };

            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();

            return productType;
        }

        public async Task<bool> UpdateProductTypeAsync(int id, ProductType productType)
        {
            var existingProductType = await _context.ProductTypes.FindAsync(id);
            if (existingProductType == null)
            {
                return false;
            }

            existingProductType.Name = productType.Name;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProductTypeAsync(int id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return false;
            }

            _context.ProductTypes.Remove(productType);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
