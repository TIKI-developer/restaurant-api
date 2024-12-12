using MediatR;

namespace Restaurant.Application.Entities.Dish.Commands.Delete
{
    public class DeleteCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
