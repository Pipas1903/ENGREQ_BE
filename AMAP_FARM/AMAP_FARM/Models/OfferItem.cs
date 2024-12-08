namespace AMAP_FARM.DTO
{
    public class OfferItem
    {
        public int Id { get; set; }
        public required int OfferId { get; set; }
        public required int ProductId { get; set; }
        public required float Price { get; set; }
        public required float SaleQuantity { get; set; }
        public float SoldQuantity { get; set; }
    }
}
