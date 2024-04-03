using System.Data.Entity;

namespace ProductService.DataAccess
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ProductContext() : base("name=ProductContext")
        {
            // Database initialization strategy
            Database.SetInitializer(new CreateDatabaseIfNotExists<ProductContext>());
        }
    }
}
