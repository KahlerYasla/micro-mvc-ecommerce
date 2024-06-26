using System.Text.Json.Serialization;

namespace WebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        [JsonPropertyName("category")]
        public required string Category { get; set; }
        [JsonPropertyName("price")]
        public required decimal Price { get; set; }
    }
}