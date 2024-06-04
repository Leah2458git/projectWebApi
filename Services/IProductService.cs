using Entities;
using Repositories;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts(string? desc,int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}