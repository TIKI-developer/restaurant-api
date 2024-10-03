using System.Collections.Generic;

namespace Restaurant.Domain
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetAllCategories();
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(Category category);
    }
}
