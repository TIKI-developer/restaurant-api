using Restaurant.Domain.Cart;
using Restaurant.Domain.Category;
using Restaurant.Domain.Order;

namespace Restaurant.Domain.Dish
{
	public class DishModel
	{
		public required Guid Id { get; set; }
		public required string Name { get; set; }
		public required float Price { get; set; }
		public string? Description { get; set; }
		public byte[]? Image { get; set; }
		public List<CategoryModel>? Categories { get; set; } = [];
        public List<CartModel>? Carts { get; set; }
        public List<OrderModel>? Orders { get; set; }
		public List<CartModelDishModel>? CartModelDishModels { get; set; }
    } 
}