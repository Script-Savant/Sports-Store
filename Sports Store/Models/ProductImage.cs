namespace Sports_Store.Models
{
    public class ProductImage
    {
        public long Id { get; set; }
        public required string ImageUrl { get; set; }

        // Navigation property
        public Product? Product { get; set; }
        public long ProductId { get; set; }
    }
}