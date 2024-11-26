using Restaurant.Domain.Category;

namespace Restaurant.Domain.Dish
{
    public class DishModel
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required float Price { get; set; }
        public string? Description { get; set; }
        public List<string> Images { get; set; } = [];
        public List<CategoryModel>? Categories { get; set; } = [];
    }
}