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

        public async Task<List<ProductType>> GetAllProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int productTypeId)
        {
            return await _context.ProductTypes.FindAsync(productTypeId);
        }

        public async Task CreateProductTypeAsync(ProductType productType)
        {
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductTypeAsync(ProductType productType)
        {
            _context.ProductTypes.Update(productType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductTypeAsync(int productTypeId)
        {
            var productType = await _context.ProductTypes.FindAsync(productTypeId);
            if (productType != null)
            {
                _context.ProductTypes.Remove(productType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
