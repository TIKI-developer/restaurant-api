using Restaurant.Domain.Dish;

namespace Restaurant.Domain.Category
{
	public class CategoryModel
	{
		public required Guid Id { get; set; }
		public required string Name { get; set; }
		public byte[]? Image { get; set; }
		public ICollection<DishModel>? Dishes { get; set; } = [];
    } 
}
