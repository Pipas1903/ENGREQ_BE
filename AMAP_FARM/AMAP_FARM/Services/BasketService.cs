using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAP_FARM.Services
{
    public class BasketService : IBasketService
    {
        private readonly AppDbContext _context;

        public BasketService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Basket> GetBasketByIdAsync(int basketId)
        {
            return await _context.Baskets.FindAsync(basketId);
        }

        public async Task<List<Basket>> GetAllBasketsAsync()
        {
            return await _context.Baskets.ToListAsync();
        }

        public async Task CreateBasketAsync(Basket basket)
        {
            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBasketAsync(Basket basket)
        {
            _context.Baskets.Update(basket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await _context.Baskets.FindAsync(basketId);
            if (basket != null)
            {
                _context.Baskets.Remove(basket);
                await _context.SaveChangesAsync();
            }
        }
    }
}
