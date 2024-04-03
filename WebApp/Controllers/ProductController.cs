using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            // Replace this with your actual logic to fetch product data
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" },
                new Product { Id = 3, Name = "Product 3" }
            };

            return products;
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}