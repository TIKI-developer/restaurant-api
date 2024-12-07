using MediatR;

namespace Restaurant.Application.Entities.Cart.Commands.CartAddDish
{
    public class CartAddDishCommand : IRequest<Unit>
    {
        public required Guid UserId { get; set; }
        public required Guid NewDish { get; set; }
    }
}
