namespace AMAP_FARM.DTO
{
    public class OfferItemDTO
    {
        public required string OfferId { get; set; }
        public required int ProductId { get; set; }
        public required float Price { get; set; }
        public required float SaleQuantity { get; set; }
        public float SoldQuantity { get; set; }
        public string DeliveryDates { get; set; }
    }
}
