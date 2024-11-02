namespace Restaurant.Application.Entities.Dish.Queries.GetDishList
{
    public class DishListViewModel
    {
        public ICollection<DishLookupDto>? Dishes { get; set; }
    }
}
