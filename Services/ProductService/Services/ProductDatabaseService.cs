using System;
using System.Collections.Generic;
using System.Linq;
using ProductService.DataAccess;
using ProductService.Models;

namespace ProductService.Services
{
    public class ProductDatabaseService
    {
        private readonly ProductContext _productContext;

        public ProductDatabaseService()
        {
            _productContext = new ProductContext();
        }
        //----------------------------------------------------------------------------------------------------------------
        public List<Product> GetProductList(ProductQuery query)
        {
            IQueryable<Product> products = _productContext.Products;

            // Apply any filtering logic based on the query parameters
            if (!string.IsNullOrEmpty(query.Category))
            {
                products = products.Where(p => p.CategoryId == _productContext.Categories.FirstOrDefault(c => c.Name == query.Category)!.Id);
            }

            // Retrieve the filtered list of products
            List<Product> productList = products.ToList();

            if (productList.Count == 0)
            {
                productList.Add(new Product
                {
                    Id = 0,
                    Name = "No products found",
                    Description = "No products found",
                    Price = 0,
                    CategoryId = 0
                });
            }

            return productList;
        }
        //----------------------------------------------------------------------------------------------------------------
        public bool CreateProduct(Product product)
        {
            try
            {
                // Add the product to the database
                _productContext.Products.Add(product);
                _productContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message + "Line" + ex.StackTrace);

                // Log or handle exception
                return false;
            }
        }
        //----------------------------------------------------------------------------------------------------------------
        public bool CreateCategory(Category category)
        {
            try
            {
                // Add the category to the database
                _productContext.Categories.Add(category);
                _productContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message + "Line" + ex.StackTrace);

                // Log or handle exception
                return false;
            }
        }
    }
}
