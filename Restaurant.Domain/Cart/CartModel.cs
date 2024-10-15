using Restaurant.Domain.Dish;
using Restaurant.Domain.User;

namespace Restaurant.Domain.Cart
{
    public class CartModel
    {
        public required ClientModel Client { get; set; }
        public ICollection<DishModel>? Dishes { get; set; }
    }
}
