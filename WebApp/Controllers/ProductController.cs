using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController()
        {
            _productService = new ProductService();
        }

        // Get all products
        [HttpGet]
        public IActionResult Get()
        {

            List<Product> products = new(){
                new() { Id = 1, Name = "Product 1", Description = "Description 1", Price = 10.00m, Category = "Category 1" },
            };

            return PartialView("_ProductsPartial", products);

        }

        // Get by category
        [HttpGet("{category}")]
        public async Task<IActionResult> Get(string category)
        {
            // Filter the products
            List<Product> products = await _productService.GetFilteredProducts(category);

            return PartialView("_ProductsPartial", products);
        }
    }
}