using exam.Models;
using System;
using System.Collections.Generic;

namespace exam.Services
{
    public class ProductService
    {

        public List<Product> GetProducts()
        {
            /*
            using (var dbContext = new YourDbContext())
            {
                var products = dbContext.Products.ToList();
                return products;
            }
            */

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.99 },
                new Product { Id = 2, Name = "Product 2", Price = 20.99 },
                new Product { Id = 3, Name = "Product 3", Price = 5.99 }
            };

            return products;
        }
    }
}

