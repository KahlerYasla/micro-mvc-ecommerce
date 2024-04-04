using System;
using System.Collections.Generic;
using System.Linq;
using ProductService.DataAccess;
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
            if (!string.IsNullOrEmpty(query.Category))
            {
                products = products.Where(p => p.CategoryId == _context.Categories.FirstOrDefault(c => c.Name == query.Category)!.Id);
            }

            // Retrieve the filtered list of products
            List<Product> productList = products.ToList();
            return productList;
        }
    }
}
