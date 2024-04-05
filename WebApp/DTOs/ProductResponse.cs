using System.Text.Json.Serialization;

namespace WebApp.DTOs
{
    public class ProductResponse
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        [JsonPropertyName("category")]
        public required Category Category { get; set; }
        [JsonPropertyName("price")]
        public required decimal Price { get; set; }
    }

    public class Category
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }
}