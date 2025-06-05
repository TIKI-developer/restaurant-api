namespace Restaurant.Domain.Entities
{
    public class Cart : Entity
    {
        public Guid UserId { get; set; }
        public required User User { get; set; }
        public List<CartDishItem> Items { get; set; } = [];
    }
}
