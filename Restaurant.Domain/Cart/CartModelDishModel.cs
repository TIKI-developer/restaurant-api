using Restaurant.Domain.Dish;

namespace Restaurant.Domain.Cart
{
	public class CartModelDishModel
	{
        public Guid CartId { get; set; }
        public CartModel? Cart { get; set; }
        public Guid DishId { get; set; }
		public DishModel? Dish { get; set; }
		public int Count { get; set; }
	}
}