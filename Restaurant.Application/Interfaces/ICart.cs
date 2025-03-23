using Restaurant.Application.Models.Cart;

namespace Restaurant.Application.Interfaces
{
    public interface ICart
    {
        ICollection<CartDto.CartItemDto> Items { get; }
    }

    public interface ICartItem
    {
        Guid DishId { get; }
        int Count { get; }
    }
}
