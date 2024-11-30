using Restaurant.Domain.Dish;

namespace Restaurant.Domain.Cart
{
    public class CartItem
    {
        public required Guid CartId { get; set; }
        public required CartModel Cart { get; set; }
        public required Guid DishId { get; set; }
        public required DishModel Dish { get; set; }
        public int Count { get; set; }
    }
}