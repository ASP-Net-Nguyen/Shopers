using Shopers.Data;
using Shopers.Models;
using Shopers.Models.Product;

namespace Shopers.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {

        private readonly DataDbContext dataDbContext;

        public CategoryService(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await dataDbContext.categories.AddAsync(category);
            await dataDbContext.SaveChangesAsync();
            return category;
        }

        public void DeleteCategory(int id)
        {
            Status status = new Status();
            var d = dataDbContext.categories.FirstOrDefault(c => c.Id == id);
            if (d != null)
            {
                dataDbContext.categories.Remove(d);
                dataDbContext.SaveChanges();
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Bài viết không tồn tại";
            }
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return dataDbContext.categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            var d = dataDbContext.categories.FirstOrDefault(c => c.Id == id);
            return d;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var model = dataDbContext.categories.Find(category.Id);
            if (model != null)
            {
                model.Name = category.Name;
            }
            await dataDbContext.SaveChangesAsync();
            return category;
        }
    }
}
