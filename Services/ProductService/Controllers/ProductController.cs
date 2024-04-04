using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetProductList([FromBody] ProductQuery query)
        {
            try
            {
                // Retrieve the list of products from the database based on the query
                List<Models.Product> productList = _productDatabaseService.GetProductList(query);

                if (productList != null && productList.Any())
                {
                    return Ok(productList);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                // Log or handle exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        //----------------------------------------------------------------------------------------------------------------
        // Create a new product
        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                // Log or handle exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        //----------------------------------------------------------------------------------------------------------------
        // Create a new category
        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                // Log or handle exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
