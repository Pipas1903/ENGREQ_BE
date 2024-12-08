using AMAP_FARM.DTO;
using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAP_FARM.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly AppDbContext _context;

        public PaymentMethodService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodsAsync()
        {
            return await _context.PaymentMethods.ToListAsync();
        }

        public async Task<PaymentMethod> GetPaymentMethodByIdAsync(int id)
        {
            return await _context.PaymentMethods.FindAsync(id);
        }

        public async Task<PaymentMethod> CreatePaymentMethodAsync(PaymentMethodCreateDto paymentMethodCreateDto)
        {
            var paymentMethod = new PaymentMethod
            {
                Name = paymentMethodCreateDto.Name
            };

            _context.PaymentMethods.Add(paymentMethod);
            await _context.SaveChangesAsync();

            return paymentMethod;
        }

        public async Task<bool> UpdatePaymentMethodAsync(int id, PaymentMethod paymentMethod)
        {
            var existingPaymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (existingPaymentMethod == null)
            {
                return false;
            }

            existingPaymentMethod.Name = paymentMethod.Name;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePaymentMethodAsync(int id)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod == null)
            {
                return false;
            }

            _context.PaymentMethods.Remove(paymentMethod);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
