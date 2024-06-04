
//using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;

namespace Repositories
{
    public class CategoryRepository :ICategoryRepository
    {

        private Shop214928673Context _shop;

        public CategoryRepository(Shop214928673Context shop)
        {
            _shop = shop;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _shop.Categories.ToListAsync();
        }

        
    }
}

