namespace Restaurant.Domain
{
    public class CartItem
    {
        public required Guid CartId { get; set; }
        public required Cart Cart { get; set; }
        public required Guid DishId { get; set; }
        public required Dish Dish { get; set; }
        public int Count { get; set; }
    }
}