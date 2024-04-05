using System;
using System.Collections.Generic;
using System.Linq;
using ProductService.Daos;
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
        public List<ProductResponse> GetProductList(ProductQuery query)
        {
            IQueryable<Product> products = _productContext.Products;

            // Apply any filtering logic based on the query parameters
            if (!string.IsNullOrEmpty(query.Category))
            {
                products = products.Where(p => p.CategoryId == _productContext.Categories.FirstOrDefault(c => c.Name == query.Category)!.Id);
            }

            // Create a list of products to return with Category included and find it from the database by CategoryId
            List<ProductResponse> productList = products.Select(p => new ProductResponse
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Category = _productContext.Categories.FirstOrDefault(c => c.Id == p.CategoryId)!
            }).ToList();

            if (productList.Count == 0)
            {
                productList.Add(new ProductResponse
                {
                    Name = "No products found",
                    Description = "No products found",
                    Price = 0,
                    Category = new Category { Id = 0, Name = "No category found" }
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
