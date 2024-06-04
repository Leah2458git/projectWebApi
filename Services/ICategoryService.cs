
using Entities;
using Repositories;

namespace Services
{
    public interface ICategoryService
    {
      
        Task<List<Category>> GetAllCategories();
        
    }
}