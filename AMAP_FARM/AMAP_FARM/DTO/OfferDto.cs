using AMAP_FARM.Models;

namespace AMAP_FARM.DTO
{
    public class OfferDto
    {
        public required int SubscriptionPeriodId { get; set; }
        public required int PaymentMethodId { get; set; }
        public required int FractionationId { get; set; }
        public List<OfferItemDTO> OfferItems { get; set; } = new List<OfferItemDTO>();
    }
}
