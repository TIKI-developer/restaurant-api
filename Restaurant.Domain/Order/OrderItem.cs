using Restaurant.Domain.Dish;

namespace Restaurant.Domain.Order
{
    public class OrderItem
    {
        public required Guid OrderId { get; set; }
        public required OrderModel Order { get; set; }
        public required Guid DishId { get; set; }
        public required DishModel Dish { get; set; }
        public int Count { get; set; }
    }
}
