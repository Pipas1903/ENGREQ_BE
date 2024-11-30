namespace AMAP_FARM.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ProductCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
