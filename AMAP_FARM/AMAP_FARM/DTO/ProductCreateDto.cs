namespace AMAP_FARM.DTO
{
    public class ProductCreateDto
    {
        public required int ProductCategoryId { get; set; }
        public required int ProductTypeId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required double Price { get; set; }
        public required double Stock { get; set; }
        public required string Unit { get; set; }
        public required int ProducerId { get; set; }
    }
}
