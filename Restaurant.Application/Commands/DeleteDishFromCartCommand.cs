using MediatR;

namespace Restaurant.Application.Commands
{
    public class DeleteDishFromCartCommand : IRequest
    {
        public required Guid DishId { get; set; }
        public required Guid UserId { get; set; }
    }
}
