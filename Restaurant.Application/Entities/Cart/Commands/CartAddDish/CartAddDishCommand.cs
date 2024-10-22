using MediatR;

namespace Restaurant.Application.Entities.Cart.Commands.CartAddDish
{
    public class CartAddDishCommand : IRequest
    {
        public required Guid ClientId { get; set; }
        public required ICollection<Guid> NewDishes { get; set; }
    }
}
