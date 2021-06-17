using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Models.Interfaces;

namespace SportsStore.Models.Data
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {Name = "Football", Price = 25},
            new Product {Name = "Surfing Board", Price = 176},
            new Product {Name = "Running shoes", Price = 99}
        }.AsQueryable<Product>();
    }
}
