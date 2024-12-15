namespace Restaurant.Domain
{
    public class Dish : Entity
    {
        public required string Name { get; set; }
        public required float Price { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required float Weight { get; set; }
        public required Content Content { get; set; }
        public List<Category>? Categories { get; set; }
    }
}