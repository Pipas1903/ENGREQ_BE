using AMAP_FARM.DTO;
using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface ICoProducerService
    {
        Task<CoProducer> GetCoProducerByUserIdAsync(int userId);
        Task<CoProducer> CreateCoProducerAsync(CoProducerCreateDto coProducerDto);
        Task<CoProducer> UpdateCoProducerAsync(int userId, CoProducerUpdateDto coProducerUpdateDto);
        Task<bool> DeleteCoProducerAsync(int userId);
    }
}
