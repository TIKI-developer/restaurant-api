using Restaurant.Domain.Dish;

namespace Restaurant.WebApi.Models.Order
{
    public class CreateOrderDto
    {
        public required ICollection<DishModel> Dishes { get; set; }
    }
}
