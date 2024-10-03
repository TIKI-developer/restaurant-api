using MediatR;

namespace Restaurant.Application.Dishes.Commands.DeleteDish
{
    public class DeleteDishCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
