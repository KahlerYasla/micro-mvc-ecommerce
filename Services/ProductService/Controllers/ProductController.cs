using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ProductDatabaseService _productDatabaseService;

        public ProductController()
        {
            _productDatabaseService = new ProductDatabaseService();
        }

        // POST: api/product
        [HttpPost]
        public IHttpActionResult GetProductList(ProductQuery query)
        {
            try
            {
                // Retrieve the list of products from the database based on the query
                List<Product> productList = _productDatabaseService.GetProductList(query);

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
                return InternalServerError(ex);
            }
        }
    }
}
