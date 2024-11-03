using Restaurant.Domain.Cart;
using Restaurant.Domain.Order;


namespace Restaurant.Domain.User.Client
{
    public class ClientModel : UserModel
    {
        protected override UserRole InitRole => UserRole.Client;
        public required ProfileModel Profile { get; set; }
        public CartModel? Cart { get; set; }
        public List<OrderModel>? Orders { get; set; } = [];

        public class ProfileModel
        {
            public string? Name { get; set; }
            public string? Address { get; set; }
        }
    }
}
