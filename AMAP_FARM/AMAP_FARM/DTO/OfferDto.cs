using AMAP_FARM.Models;

namespace AMAP_FARM.DTO
{
    public class OfferDto
    {
        public int Id { get; set; }
        public required int SubscriptionPeriodId { get; set; }
        public required int PaymentMethodId { get; set; }
        public required int FractionationId { get; set; }
        public List<OfferItem> OfferItems { get; set; } = new List<OfferItem>();
    }
}
