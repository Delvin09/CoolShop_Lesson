using System.ComponentModel.DataAnnotations;

namespace CoolShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(400)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? DiscountPrice { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int Ratio { get; set; }

        [Required]
        [StringLength(200)]
        public string Category { get; set; }
    }
}
