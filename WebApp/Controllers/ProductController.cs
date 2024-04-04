using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        // Dummy data for testing
        private static List<Product> productsListFromDB = new List<Product>
            {
                new Product { Id = 1, Name = "CWPC", Description = "Complete Web Dev Course", Price = 10.0m, Category = "Csharp" },
                new Product { Id = 2, Name = "Intro Py", Description = "Intro to Python", Price = 5.0m, Category = "Python" },
                new Product { Id = 3, Name = "Adv Py", Description = "Advanced Python", Price = 7.0m, Category = "Python" },
                new Product { Id = 4, Name = "Intro JS", Description = "Intro to JavaScript", Price = 5.0m, Category = "JavaScript" },
                new Product { Id = 5, Name = "Adv JS", Description = "Advanced JavaScript", Price = 7.0m, Category = "JavaScript" },
                new Product { Id = 6, Name = "Intro C#", Description = "Intro to C#", Price = 5.0m, Category = "Csharp" },
                new Product { Id = 7, Name = "Adv C#", Description = "Advanced C#", Price = 7.0m, Category = "Csharp" },
                new Product { Id = 8, Name = "Intro Java", Description = "Intro to Java", Price = 5.0m, Category = "Java" },
                new Product { Id = 9, Name = "Adv Java", Description = "Advanced Java", Price = 7.0m, Category = "Java" },
            };

        // Get all products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productsListFromDB;
        }

        // Get by category
        [HttpGet("{category}")]
        public IActionResult Get(string category)
        {
            // Split the categories
            string[] categories = category.Split(',');

            // Filter the products
            List<Product> products = new List<Product>();
            foreach (var cat in categories)
            {
                foreach (var product in ProductsController.productsListFromDB)
                {
                    if (product.Category == cat)
                    {
                        products.Add(product);
                    }
                }
            }

            return PartialView("_ProductsPartial", products);
        }
    }
}