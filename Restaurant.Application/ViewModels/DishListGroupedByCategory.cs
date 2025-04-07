namespace Restaurant.Application.ViewModels
{
    public class DishListGroupedByCategory
    {
        public List<CategoryDishesDto> CategoriesDishes { get; set; } = [];
    }

    public class CategoryDishesDto
    {
        public required Guid CategoryId { get; set; }
        public ICollection<DishItem>? Dishes { get; set; }
    }
}
