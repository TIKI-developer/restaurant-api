using Restaurant.Domain.Category;
using Restaurant.Domain.User.Client;

namespace Restaurant.Domain.Dish
{
	public class DishModel
	{
		public required Guid Id { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }
		public required float Price { get; set; }
		public byte[]? Image { get; set; }
		public ICollection<CategoryModel>? Categories { get; set; } = [];
    } 
}