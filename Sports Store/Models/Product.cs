using System.ComponentModel.DataAnnotations.Schema;

namespace Sports_Store.Models
{
    public class Product
    {
        public long? Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        public string Category { get; set; } = string.Empty;

        public ICollection<ProductImage> ProductImages {get; set;} = new List<ProductImage>();
    }
}