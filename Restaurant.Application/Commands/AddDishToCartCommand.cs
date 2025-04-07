using MediatR;

namespace Restaurant.Application.Commands
{
    public class AddDishToCartCommand : IRequest<Unit>
    {
        public required Guid UserId { get; set; }
        public required Guid DishId { get; set; }
    }
}
