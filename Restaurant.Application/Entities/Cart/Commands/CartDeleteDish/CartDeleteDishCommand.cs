using MediatR;

namespace Restaurant.Application.Entities.Cart.Commands.CartDeleteDish
{
    public class CartDeleteDishCommand : IRequest 
    { 
        public required Guid DishId { get; set; }
        public required Guid UserId { get; set; }
    }
}
