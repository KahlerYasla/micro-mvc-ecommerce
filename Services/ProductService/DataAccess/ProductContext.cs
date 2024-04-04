using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.DataAccess
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
