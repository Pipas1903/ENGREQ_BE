namespace AMAP_FARM.Models
{
    public class Product
    {
        public int ProductId { get; set; }            // Primary key for the product
        public string Name { get; set; }              // Name of the product
        public int ProductCategoryId { get; set; }    // Foreign key to the ProductCategory
        public string Description { get; set; }       // Description of the product
        public decimal Price { get; set; }            // Price of the product
        public int Stock { get; set; }                // Stock of the product
    }
}
