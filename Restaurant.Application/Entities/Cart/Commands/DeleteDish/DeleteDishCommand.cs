using MediatR;

namespace Restaurant.Application.Entities.Cart.Commands.DeleteDish
{
    public class DeleteDishCommand : IRequest
    {
        public required Guid DishId { get; set; }
        public required Guid UserId { get; set; }
    }
}
