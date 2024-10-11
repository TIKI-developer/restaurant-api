namespace Restaurant.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public ICollection<Dish>? Dishes { get; set; }
        public DateTime CreationDateTime { get; set; }
        public required User Client { get; set; }
    }
}
