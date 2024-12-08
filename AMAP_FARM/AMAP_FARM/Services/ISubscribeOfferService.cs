using AMAP_FARM.DTO;

namespace AMAP_FARM.Services
{
    public interface ISubscribeOfferService
    {
        Task<SubscribeOfferDto> CreateSubscribeOfferAsync(SubscribeOfferCreateDto subscribeOfferCreateDto);
        Task<SubscribeOfferDto> GetSubscribeOfferByIdAsync(int id);
        Task<List<SubscribeOfferDto>> GetAllSubscribeOffersAsync();
        Task<SubscribeOfferDto> UpdateSubscribeOfferAsync(int id, SubscribeOfferCreateDto subscribeOfferCreateDto);
        Task<bool> DeleteSubscribeOfferAsync(int id);
    }
}
