using Restaurant.Domain.User;

namespace Restaurant.Domain.Cart
{
    public class CartModel
    {
        public Guid UserId { get; set; }
        public required UserModel User { get; set; }
        public List<CartItem>? Items { get; set; }
    }
}
