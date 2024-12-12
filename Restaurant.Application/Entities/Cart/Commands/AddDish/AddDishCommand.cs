using MediatR;

namespace Restaurant.Application.Entities.Cart.Commands.AddDish
{
    public class AddDishCommand : IRequest<Unit>
    {
        public required Guid UserId { get; set; }
        public required Guid DishId { get; set; }
    }
}
