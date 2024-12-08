using AMAP_FARM.DTO;
using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAP_FARM.Services
{
    public class SubscribeOfferService : ISubscribeOfferService
    {
        private readonly AppDbContext _context;

        public SubscribeOfferService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SubscribeOfferDto> CreateSubscribeOfferAsync(SubscribeOfferCreateDto subscribeOfferDto)
        {
            // Criar a nova oferta de assinatura
            var subscribeOffer = new SubscribeOffer
            {
                CoProducerId = subscribeOfferDto.CoProducerId,
                Total = subscribeOfferDto.Total
            };

            _context.SubscribeOffers.Add(subscribeOffer);
            await _context.SaveChangesAsync();

            var subscribeOfferItems = subscribeOfferDto.SubscribeOfferItems.Select(item => new SubscribeOfferItem
            {
                SubscribeOfferId = subscribeOffer.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Date = item.Date,
                PaymentMethodId = item.PaymentMethodId,
                FractionationId = item.FractionationId
            }).ToList();

            _context.SubscribeOfferItems.AddRange(subscribeOfferItems);
            await _context.SaveChangesAsync();

            return new SubscribeOfferDto
            {
                Id = subscribeOffer.Id,
                CoProducerId = subscribeOffer.CoProducerId,
                Total = subscribeOffer.Total,
                SubscribeOfferItems = subscribeOfferItems
            };
        }

        public async Task<SubscribeOfferDto> GetSubscribeOfferByIdAsync(int id)
        {
            var subscribeOffer = await _context.SubscribeOffers
                .FirstOrDefaultAsync(so => so.Id == id);

            if (subscribeOffer == null)
            {
                return null;
            }

            var subscribeOfferItems = await _context.SubscribeOfferItems
                .Where(soi => soi.SubscribeOfferId == id)
                .ToListAsync();

            return new SubscribeOfferDto
            {
                Id = subscribeOffer.Id,
                CoProducerId = subscribeOffer.CoProducerId,
                Total = subscribeOffer.Total,
                SubscribeOfferItems = subscribeOfferItems
            };
        }

        public async Task<List<SubscribeOfferDto>> GetAllSubscribeOffersAsync()
        {
            var subscribeOffers = await _context.SubscribeOffers.ToListAsync();

            var subscribeOfferDtos = new List<SubscribeOfferDto>();

            foreach (var subscribeOffer in subscribeOffers)
            {
                var subscribeOfferItems = await _context.SubscribeOfferItems
                    .Where(soi => soi.SubscribeOfferId == subscribeOffer.Id)
                    .ToListAsync();

                subscribeOfferDtos.Add(new SubscribeOfferDto
                {
                    Id = subscribeOffer.Id,
                    CoProducerId = subscribeOffer.CoProducerId,
                    Total = subscribeOffer.Total,
                    SubscribeOfferItems = subscribeOfferItems
                });
            }

            return subscribeOfferDtos;
        }

        public async Task<SubscribeOfferDto> UpdateSubscribeOfferAsync(int id, SubscribeOfferCreateDto subscribeOfferDto)
        {
            var subscribeOffer = await _context.SubscribeOffers
                .FirstOrDefaultAsync(so => so.Id == id);

            if (subscribeOffer == null)
            {
                return null;
            }

            subscribeOffer.CoProducerId = subscribeOfferDto.CoProducerId;
            subscribeOffer.Total = subscribeOfferDto.Total;

            _context.SubscribeOffers.Update(subscribeOffer);

            _context.SubscribeOfferItems.RemoveRange(_context.SubscribeOfferItems.Where(soi => soi.SubscribeOfferId == subscribeOffer.Id));

            var subscribeOfferItems = subscribeOfferDto.SubscribeOfferItems.Select(item => new SubscribeOfferItem
            {
                SubscribeOfferId = subscribeOffer.Id,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Date = item.Date,
                PaymentMethodId = item.PaymentMethodId,
                FractionationId = item.FractionationId
            }).ToList();

            _context.SubscribeOfferItems.AddRange(subscribeOfferItems);
            await _context.SaveChangesAsync();

            return new SubscribeOfferDto
            {
                Id = subscribeOffer.Id,
                CoProducerId = subscribeOffer.CoProducerId,
                Total = subscribeOffer.Total,
                SubscribeOfferItems = subscribeOfferItems
            };
        }

        public async Task<bool> DeleteSubscribeOfferAsync(int id)
        {
            var subscribeOffer = await _context.SubscribeOffers
                .FirstOrDefaultAsync(so => so.Id == id);

            if (subscribeOffer == null)
            {
                return false;
            }

            _context.SubscribeOfferItems.RemoveRange(_context.SubscribeOfferItems.Where(soi => soi.SubscribeOfferId == subscribeOffer.Id));
            _context.SubscribeOffers.Remove(subscribeOffer);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
