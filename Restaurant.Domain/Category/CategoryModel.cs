using Restaurant.Domain.Dish;

namespace Restaurant.Domain.Category
{
    public class CategoryModel
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Image { get; set; }
        public List<DishModel>? Dishes { get; set; } = [];
    }
}
