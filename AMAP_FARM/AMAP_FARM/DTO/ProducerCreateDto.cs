namespace AMAP_FARM.DTO
{
    public class ProducerCreateDto : UserCreateDto
    {
        public required string FarmName { get; set; }
        public required string Location { get; set; }
        public required string ContactNumber { get; set; }
    }
}
