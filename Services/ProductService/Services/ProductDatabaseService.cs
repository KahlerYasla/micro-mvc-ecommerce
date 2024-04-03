using System;
using System.Collections.Generic;
using System.Linq;
using ProductService.Models;

namespace ProductService.Services
{
    public class ProductDatabaseService
    {
        private readonly ProductContext _context;

        public ProductDatabaseService()
        {
            _context = new ProductContext();
        }

        public List<Product> GetProductList(ProductQuery query)
        {
            IQueryable<Product> products = _context.Products;

            // Apply any filtering logic based on the query parameters
            if (!string.IsNullOrEmpty(query.Name))
            {
                products = products.Where(p => p.Name.Contains(query.Name));
            }

            // Example of additional filtering logic
            // if (query.CategoryId.HasValue)
            // {
            //     products = products.Where(p => p.CategoryId == query.CategoryId.Value);
            // }

            // Retrieve the filtered list of products
            List<Product> productList = products.ToList();
            return productList;
        }
    }
}
