using System.Collections.Generic;

namespace Restaurant.Domain
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _repository.GetAllCategories();
        }

        public void AddCategory(Category category)
        {
            _repository.AddCategory(category);
        }

        public void DeleteCategory(Category category)
        {
            _repository.DeleteCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            _repository.UpdateCategory(category);
        }
    }
}
