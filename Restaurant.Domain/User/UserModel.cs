using Restaurant.Domain.Cart;
using Restaurant.Domain.Order;

namespace Restaurant.Domain.User
{
    public abstract class UserModel
    {
        public Guid Id { get; set; }
        public required ProfileModel Profile { get; set; }
        public CartModel? Cart { get; set; }
        public List<OrderModel>? Orders { get; set; } = [];
        public required string Number { get; set; }
        public abstract List<UserRole> Roles { get; }
        public class ProfileModel
        {
            public string? Name { get; set; }
            public string? Address { get; set; }
        }
    }
    public enum UserRole
    {
        Client,
        Admin
    }
}