
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Required, MaxLength(30, ErrorMessage = "שם המוצר מוגבל ל30 תווים")]
        public string ProductName { get; set; } = null!;

        [Required]
        public int Price { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? ImageUrl { get; set; }

        

    }
}
