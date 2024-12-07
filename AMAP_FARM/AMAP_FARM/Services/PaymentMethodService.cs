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

        public async Task<List<PaymentMethod>> GetAllPaymentMethodsAsync()
        {
            return await _context.PaymentMethods.ToListAsync();
        }

        public async Task<PaymentMethod> GetPaymentMethodByIdAsync(int paymentMethodId)
        {
            return await _context.PaymentMethods
                .FirstOrDefaultAsync(pm => pm.Id == paymentMethodId);
        }

        public async Task CreatePaymentMethodAsync(PaymentMethod paymentMethod)
        {
            await _context.PaymentMethods.AddAsync(paymentMethod);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentMethodAsync(PaymentMethod paymentMethod)
        {
            _context.PaymentMethods.Update(paymentMethod);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaymentMethodAsync(int paymentMethodId)
        {
            var paymentMethod = await _context.PaymentMethods
                .FirstOrDefaultAsync(pm => pm.Id == paymentMethodId);

            if (paymentMethod != null)
            {
                _context.PaymentMethods.Remove(paymentMethod);
                await _context.SaveChangesAsync();
            }
        }
    }
}

