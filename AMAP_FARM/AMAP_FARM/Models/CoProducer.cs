namespace AMAP_FARM.Models
{
    public class CoProducer
    {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required string Location { get; set; }
        public required string ContactNumber { get; set; }
    }
}
