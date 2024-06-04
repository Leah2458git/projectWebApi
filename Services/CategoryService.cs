using System.Text.Json;
using Entities;
using Repositories;
namespace Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryrepository;
        public CategoryService(ICategoryRepository categoryrepository)
        {
            _categoryrepository = categoryrepository;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryrepository.GetAllCategories();
        }

     

      
        

    }
}

    

