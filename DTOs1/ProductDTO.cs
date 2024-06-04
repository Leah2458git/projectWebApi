using Entities;
using System.Text.Json.Serialization;

namespace DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Price { get; set; }

        public int CategoryName { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }


    }
}
