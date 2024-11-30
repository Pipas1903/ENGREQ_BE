using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IBasketService
    {
        Task<List<Basket>> GetAllBasketsAsync();
        Task<Basket> GetBasketByIdAsync(int basketId);
        Task CreateBasketAsync(Basket basket);
        Task UpdateBasketAsync(Basket basket);
        Task DeleteBasketAsync(int basketId);
    }
}
