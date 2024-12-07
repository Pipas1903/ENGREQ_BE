namespace AMAP_FARM.DTO
{
    public class OfferItem
    {
        public int Id { get; set; }
        public required int OfferId { get; set; }
        public required int ProductId { get; set; }
        public required decimal Price { get; set; }
        public required int SaleQuantity { get; set; }
        public int SoldQuantity { get; set; }
    }
}
