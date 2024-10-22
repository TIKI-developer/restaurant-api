using Restaurant.Domain.Dish;
using Restaurant.Domain.User.Client;

namespace Restaurant.Domain.Cart
{
    public class CartModel
    {
        public Guid ClientId { get; set; }
        public List<DishModel>? Dishes { get; set; }
        public required ClientModel Client { get; set; }
    }
}
