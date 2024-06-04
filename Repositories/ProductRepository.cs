
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {

        private Shop214928673Context _shop;

        public ProductRepository(Shop214928673Context shop)
        {
            _shop = shop;
        }





        public async Task<List<Product>> GetAllProducts(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _shop.Products
                .Where(product =>
                    (desc == null ? true : product.ProductName.Contains(desc))
                    && (minPrice == null ? true : product.Price >= minPrice)
                    && (maxPrice == null ? true : product.Price <= maxPrice)
                    && (categoryIds.Length == 0 ? true : categoryIds.Contains(product.CategoryId))
                )
                .OrderBy(product => product.Price);//.Include(p => p.Category);

            Console.WriteLine(query.ToQueryString());

            List<Product> products = await query.ToListAsync();
            return products;
        }


    }
}

