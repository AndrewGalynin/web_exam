using exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace exam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        public ProductsController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        [HttpGet]
        [ResponseCache(Duration = 60)] // кешувати на 60 секунд
        public IActionResult GetProducts()
        {
            if (_cache.TryGetValue("Products", out List<Product> cachedProducts))
            {
                return Ok(cachedProducts);
            }

            var products = GetProductsFromDatabase();

            _cache.Set("Products", products, TimeSpan.FromSeconds(60));

            return Ok(products);
        }

        private List<Product> GetProductsFromDatabase()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.99 },
                new Product { Id = 2, Name = "Product 2", Price = 20.49 },
                new Product { Id = 3, Name = "Product 3", Price = 5.99 }
            };

            return products;
        }
    }
}

