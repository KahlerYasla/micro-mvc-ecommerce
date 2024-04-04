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

        // POST: api/product
        [HttpPost]
        public IActionResult GetProductList([FromBody] ProductQuery query)
        {
            DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");

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
                // Log or handle exception
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
