using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.DataAccess
{
    public class ProductContext : DbContext
    {
        public ProductContext() { }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
