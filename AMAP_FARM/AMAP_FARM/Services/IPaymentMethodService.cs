using AMAP_FARM.Models;

namespace AMAP_FARM.Services
{
    public interface IPaymentMethodService
    {
        Task<List<PaymentMethod>> GetAllPaymentMethodsAsync();
        Task<PaymentMethod> GetPaymentMethodByIdAsync(int paymentMethodId);
        Task CreatePaymentMethodAsync(PaymentMethod paymentMethod);
        Task UpdatePaymentMethodAsync(PaymentMethod paymentMethod);
        Task DeletePaymentMethodAsync(int paymentMethodId);
    }
}

