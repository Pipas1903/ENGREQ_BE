namespace AMAP_FARM.Models
{
    public class SubscribeOfferItem
    {
        public int Id { get; set; }
        public required int SubscribeOfferId { get; set; }
        public required int ProductId { get; set; }
        public required float Quantity { get; set; }
        public required DateTime Date { get; set; }
        public required int PaymentMethodId { get; set; }
        public required int FractionationId { get; set; }
    }
}
