using Restaurant.Domain.Dish;
using Restaurant.Domain.Order;


namespace Restaurant.Domain.User.Client
{
    public class ClientModel : UserModel
    {
        public override UserRole Role => UserRole.Client;
        public ProfileModel Profile { get; set; }
        public CartModel Cart { get; set; }
        public ICollection<OrderModel>? Orders { get; set; } = [];
        public class CartModel
        {
            public ICollection<DishModel>? Dishes { get; set; } = [];
        }
        public class ProfileModel
        {
            public string? Name { get; set; }
        }
    }
}
