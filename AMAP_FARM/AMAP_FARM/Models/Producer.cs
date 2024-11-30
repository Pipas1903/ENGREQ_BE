namespace AMAP_FARM.Models
{
    public class Producer : User
    {
        public required string FarmName { get; set; }
        public required string Location { get; set; }
        public required string ContactNumber { get; set; }
    }
}
