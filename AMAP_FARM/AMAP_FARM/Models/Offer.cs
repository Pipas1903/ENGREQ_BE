namespace AMAP_FARM.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public required int SubscriptionPeriodId { get; set; }
        public required int PaymentMethodId { get; set; }
        public required int FractionationId { get; set; }
    }
}
