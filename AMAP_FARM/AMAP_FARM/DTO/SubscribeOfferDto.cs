using AMAP_FARM.Models;

namespace AMAP_FARM.DTO
{
    public class SubscribeOfferDto
    {
        public int Id { get; set; }
        public required int CoProducerId { get; set; }
        public required float Total { get; set; }
        public List<SubscribeOfferItem> SubscribeOfferItems { get; set; } = new List<SubscribeOfferItem>();
    }
}
