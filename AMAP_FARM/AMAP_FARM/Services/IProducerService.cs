using AMAP_FARM.DTO;
using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IProducerService
    {
        Task<Producer> GetProducerByUserIdAsync(int userId);
        Task<Producer> CreateProducerAsync(ProducerCreateDto producerDto);
        Task<Producer> UpdateProducerAsync(int userId, ProducerUpdateDto producerUpdateDto);
        Task<bool> DeleteProducerAsync(int userId);
    }
}

