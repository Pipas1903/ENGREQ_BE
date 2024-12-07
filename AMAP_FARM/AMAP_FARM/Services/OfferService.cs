using AMAP_FARM.DTO;
using AMAP_FARM.Models;
using AMAP_FARM.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMAP_FARM.Services
{
    public class OfferService : IOfferService
    {
        private readonly AppDbContext _context;

        public OfferService(AppDbContext context)
        {
            _context = context;
        }

        // Criar uma nova oferta com os OfferItems
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

            var createdOfferDto = new OfferDto
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

            return createdOfferDto;
        }

        public async Task<OfferDto> GetOfferByIdAsync(int id)
        {
            var offer = await _context.Offers
                .Include(o => o.OfferItems)  // Inclui os itens da oferta
                .FirstOrDefaultAsync(o => o.Id == id);

            if (offer == null)
            {
                return null;
            }

            return new OfferDto
            {
                Id = offer.Id,
                SubscriptionPeriodId = offer.SubscriptionPeriodId,
                PaymentMethodId = offer.PaymentMethodId,
                FractionationId = offer.FractionationId,
                OfferItems = offer.OfferItems.Select(item => new OfferItem
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
            var offers = await _context.Offers
                .Include(o => o.OfferItems)
                .ToListAsync();

            return offers.Select(offer => new OfferDto
            {
                Id = offer.Id,
                SubscriptionPeriodId = offer.SubscriptionPeriodId,
                PaymentMethodId = offer.PaymentMethodId,
                FractionationId = offer.FractionationId,
                OfferItems = offer.OfferItems.Select(item => new OfferItem
                {
                    Id = item.Id,
                    OfferId = item.OfferId,
                    ProductId = item.ProductId,
                    Price = item.Price,
                    SaleQuantity = item.SaleQuantity,
                    SoldQuantity = item.SoldQuantity
                }).ToList()
            }).ToList();
        }

        public async Task<OfferDto> UpdateOfferAsync(int id, OfferDto offerDto)
        {
            var offer = await _context.Offers
                .Include(o => o.OfferItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (offer == null)
            {
                return null;
            }

            offer.SubscriptionPeriodId = offerDto.SubscriptionPeriodId;
            offer.PaymentMethodId = offerDto.PaymentMethodId;
            offer.FractionationId = offerDto.FractionationId;

            _context.Offers.Update(offer);

            _context.OfferItems.RemoveRange(offer.OfferItems);

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
                .Include(o => o.OfferItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (offer == null)
            {
                return false;
            }

            _context.OfferItems.RemoveRange(offer.OfferItems);

            _context.Offers.Remove(offer);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
