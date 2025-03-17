namespace Restaurant.Application.ViewModels
{
    public class DishListGroupedByCategory
    {
        public Dictionary<Guid, ICollection<DishLookup>> CategoriesDishes { get; set; } = [];
    }
}
