using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApp.Models;
using System.Text.Json;
using WebApp.DTOs;

namespace WebApp.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5158/api/")
            };
        }

        public async Task<List<Product>> GetFilteredProducts(string category)
        {
            string requestUri = "Product/GetProductList";

            var response = await _httpClient.PostAsJsonAsync(requestUri, new ProductQuery { Category = category });

            Console.WriteLine(response);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);

            response.EnsureSuccessStatusCode();

            var responseBody = response.Content.ReadAsStringAsync().Result;

            List<ProductResponse> rawResponse = JsonSerializer.Deserialize<List<ProductResponse>>(responseBody)!;

            List<Product> result = new();
            foreach (var product in rawResponse)
            {
                result.Add(new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Category = product.Category.Name
                });
            }

            return result;
        }
    }
}