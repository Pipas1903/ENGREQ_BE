using AMAP_FARM.DTO;
using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAP_FARM.Services
{
    public class OfferService : IOfferService
    {
        private readonly AppDbContext _context;

        public OfferService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OfferDto> CreateOfferAsync(OfferDto offerDto)
        {
            var offer = new Offer
            {
                SubscriptionPeriodId = offerDto.SubscriptionPeriodId,
                PaymentMethodId = offerDto.PaymentMethodId,
                FractionationId = offerDto.FractionationId
            };

            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();

            var offerItems = offerDto.OfferItems.Select(item => new OfferItem
            {
                OfferId = offer.Id,
                ProductId = item.ProductId,
                Price = item.Price,
                SaleQuantity = item.SaleQuantity,
                SoldQuantity = item.SoldQuantity
            }).ToList();

            _context.OfferItems.AddRange(offerItems);
            await _context.SaveChangesAsync();

            return new OfferDto
            {
                Id = offer.Id,
                SubscriptionPeriodId = offer.SubscriptionPeriodId,
                PaymentMethodId = offer.PaymentMethodId,
                FractionationId = offer.FractionationId,
                OfferItems = offerItems.Select(item => new OfferItem
                {
                    Id = item.Id,
                    OfferId = item.OfferId,
                    ProductId = item.ProductId,
                    Price = item.Price,
                    SaleQuantity = item.SaleQuantity,
                    SoldQuantity = item.SoldQuantity
                }).ToList()
            };
        }


        public async Task<OfferDto> GetOfferByIdAsync(int id)
        {
            var offer = await _context.Offers
                .FirstOrDefaultAsync(o => o.Id == id);

            if (offer == null)
            {
                return null;
            }

            var offerItems = await _context.OfferItems
                .Where(oi => oi.OfferId == id)
                .ToListAsync();

            return new OfferDto
            {
                Id = offer.Id,
                SubscriptionPeriodId = offer.SubscriptionPeriodId,
                PaymentMethodId = offer.PaymentMethodId,
                FractionationId = offer.FractionationId,
                OfferItems = offerItems.Select(item => new OfferItem
                {
                    Id = item.Id,
                    OfferId = item.OfferId,
                    ProductId = item.ProductId,
                    Price = item.Price,
                    SaleQuantity = item.SaleQuantity,
                    SoldQuantity = item.SoldQuantity
                }).ToList()
            };
        }


        public async Task<List<OfferDto>> GetAllOffersAsync()
        {
            var offers = await _context.Offers.ToListAsync();

            var offerDtos = new List<OfferDto>();

            foreach (var offer in offers)
            {
                var offerItems = await _context.OfferItems
                    .Where(oi => oi.OfferId == offer.Id)
                    .ToListAsync();

                offerDtos.Add(new OfferDto
                {
                    Id = offer.Id,
                    SubscriptionPeriodId = offer.SubscriptionPeriodId,
                    PaymentMethodId = offer.PaymentMethodId,
                    FractionationId = offer.FractionationId,
                    OfferItems = offerItems.Select(item => new OfferItem
                    {
                        Id = item.Id,
                        OfferId = item.OfferId,
                        ProductId = item.ProductId,
                        Price = item.Price,
                        SaleQuantity = item.SaleQuantity,
                        SoldQuantity = item.SoldQuantity
                    }).ToList()
                });
            }

            return offerDtos;
        }


        public async Task<OfferDto> UpdateOfferAsync(int id, OfferDto offerDto)
        {
            var offer = await _context.Offers
                .FirstOrDefaultAsync(o => o.Id == id);

            if (offer == null)
            {
                return null;
            }

            offer.SubscriptionPeriodId = offerDto.SubscriptionPeriodId;
            offer.PaymentMethodId = offerDto.PaymentMethodId;
            offer.FractionationId = offerDto.FractionationId;

            _context.Offers.Update(offer);

            _context.OfferItems.RemoveRange(_context.OfferItems.Where(oi => oi.OfferId == offer.Id));

            var offerItems = offerDto.OfferItems.Select(item => new OfferItem
            {
                OfferId = offer.Id,
                ProductId = item.ProductId,
                Price = item.Price,
                SaleQuantity = item.SaleQuantity,
                SoldQuantity = item.SoldQuantity
            }).ToList();

            _context.OfferItems.AddRange(offerItems);
            await _context.SaveChangesAsync();

            return new OfferDto
            {
                Id = offer.Id,
                SubscriptionPeriodId = offer.SubscriptionPeriodId,
                PaymentMethodId = offer.PaymentMethodId,
                FractionationId = offer.FractionationId,
                OfferItems = offerItems.Select(item => new OfferItem
                {
                    Id = item.Id,
                    OfferId = item.OfferId,
                    ProductId = item.ProductId,
                    Price = item.Price,
                    SaleQuantity = item.SaleQuantity,
                    SoldQuantity = item.SoldQuantity
                }).ToList()
            };
        }


        public async Task<bool> DeleteOfferAsync(int id)
        {
            var offer = await _context.Offers
                .FirstOrDefaultAsync(o => o.Id == id);

            if (offer == null)
            {
                return false;
            }

            _context.OfferItems.RemoveRange(_context.OfferItems.Where(oi => oi.OfferId == offer.Id));

            _context.Offers.Remove(offer);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
