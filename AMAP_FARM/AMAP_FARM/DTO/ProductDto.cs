namespace AMAP_FARM.DTO
{
    public class ProductDto
    {
        public int ProductCategoryId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public double Stock { get; set; }
        public required string Unit { get; set; }
        public int ProducerId { get; set; }
    }
}
