namespace Restaurant.Domain.Entities
{
    public class Category : Entity
    {
        public required string Name { get; set; }
        public required string Image { get; set; }
        public required Content Content { get; set; }
        public List<Dish>? Dishes { get; set; } = [];
    }
}
