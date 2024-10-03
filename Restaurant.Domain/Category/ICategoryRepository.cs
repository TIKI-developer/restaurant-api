using System.Collections.Generic;

namespace Restaurant.Domain
{
	public interface ICategoryRepository
	{
		public IEnumerable<Category> GetAllCategories();
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(Category category);
    }

}