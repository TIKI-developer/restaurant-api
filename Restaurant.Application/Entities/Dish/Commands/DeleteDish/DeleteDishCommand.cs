using MediatR;

namespace Restaurant.Application.Entities.Dish.Commands.DeleteDish
{
    public class DeleteDishCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
