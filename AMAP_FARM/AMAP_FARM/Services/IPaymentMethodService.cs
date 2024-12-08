using AMAP_FARM.DTO;
using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodsAsync();
        Task<PaymentMethod> GetPaymentMethodByIdAsync(int id);
        Task<PaymentMethod> CreatePaymentMethodAsync(PaymentMethodCreateDto paymentMethodCreateDto);
        Task<bool> UpdatePaymentMethodAsync(int id, PaymentMethod paymentMethod);
        Task<bool> DeletePaymentMethodAsync(int id);
    }
}
