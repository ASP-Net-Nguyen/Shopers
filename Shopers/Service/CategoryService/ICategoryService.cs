using Shopers.Models;
using Shopers.Models.Product;

namespace Shopers.Service.CategoryService
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategory();
        Category GetCategoryById(int id);
        Task<Category> CreateCategory (Category category);
        Task<Category> UpdateCategory (Category category);
        void DeleteCategory (int id);
    }
}
