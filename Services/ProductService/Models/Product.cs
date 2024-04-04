namespace ProductService.Models
{
    public class Product
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int CategoryId { get; set; }
    }
}
