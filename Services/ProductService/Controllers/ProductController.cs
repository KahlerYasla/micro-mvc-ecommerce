using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Daos;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDatabaseService _productDatabaseService;

        public ProductController()
        {
            _productDatabaseService = new ProductDatabaseService();
        }
        //----------------------------------------------------------------------------------------------------------------
        // POST: api/product
        [HttpPost("GetProductList")]
        public ActionResult<List<Product>> GetProductList([FromBody] ProductQuery query)
        {
            Console.WriteLine("\nGetProductList called\n");

            string[] queriesSplitted = query.Category?.Split(',')!;

            List<ProductResponse> resultList = new();

            foreach (var category in queriesSplitted)
            {
                resultList.AddRange(_productDatabaseService.GetProductList(new ProductQuery { Category = category }));
            }

            Console.WriteLine(resultList.Count);

            foreach (var product in resultList)
            {
                Console.WriteLine(product.Name);
            }

            return Ok(resultList);
        }
        //----------------------------------------------------------------------------------------------------------------
        // Create a new product
        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct([FromBody] Product product)
        {

            // Add the product to the database
            bool result = _productDatabaseService.CreateProduct(product);

            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        //----------------------------------------------------------------------------------------------------------------
        // Create a new category
        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            // Add the category to the database
            bool result = _productDatabaseService.CreateCategory(category);

            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

    }
}
