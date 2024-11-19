using Restaurant.Domain.User.Client;

namespace Restaurant.Domain.Cart
{
    public class CartModel
    {
        public Guid ClientId { get; set; }
        public required ClientModel Client { get; set; }
        public List<CartItem>? Items { get; set; }
    }
}
