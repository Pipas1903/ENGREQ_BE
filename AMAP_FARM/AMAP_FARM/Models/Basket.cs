namespace AMAP_FARM.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public double Stock { get; set; }
        public required string Unit { get; set; }
        public int ProducerId { get; set; }
        public required List<int> ProductId { get; set; }
    }
}