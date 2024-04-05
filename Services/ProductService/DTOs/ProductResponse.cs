using ProductService.Models;

namespace ProductService.Daos
{
    public class ProductResponse
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required Category Category { get; set; }
    }
}