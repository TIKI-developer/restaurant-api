namespace Restaurant.Domain.Entities
{
    public class OrderItem
    {
        public required Guid OrderId { get; set; }
        public required Order Order { get; set; }
        public required Guid DishId { get; set; }
        public required Dish Dish { get; set; }
        public int Count { get; set; }
    }
}
