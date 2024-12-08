namespace AMAP_FARM.Models
{
    public class SubscribeOffer
    {
        public int Id { get; set; }
        public required int CoProducerId { get; set; }
        public required float Total { get; set; }
    }
}
