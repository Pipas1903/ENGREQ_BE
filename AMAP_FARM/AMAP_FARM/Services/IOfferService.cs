using AMAP_FARM.DTO;

namespace AMAP_FARM.Services
{
    public interface IOfferService
    {
        Task<OfferDto> CreateOfferAsync(OfferDto offerDto);

        Task<OfferDto> GetOfferByIdAsync(int id);

        Task<List<OfferDto>> GetAllOffersAsync();

        Task<OfferDto> UpdateOfferAsync(int id, OfferDto offerDto);

        Task<bool> DeleteOfferAsync(int id);
    }
}
