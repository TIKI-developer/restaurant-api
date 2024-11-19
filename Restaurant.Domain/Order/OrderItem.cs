using Restaurant.Domain.Dish;

namespace Restaurant.Domain.Order
{
    public class OrderItem
    {
        public Guid OrderId { get; set; }
        public OrderModel? Order { get; set; }
        public Guid DishId { get; set; }
        public DishModel? Dish { get; set; }
        public int Count { get; set; }
    }
}
