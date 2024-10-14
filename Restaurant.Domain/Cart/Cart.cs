namespace Restaurant.Domain
{
    public class Cart
    {
        public Guid UserId { get; set; }
        public ICollection<Dish>? Dishes { get; set; }
    }
}
