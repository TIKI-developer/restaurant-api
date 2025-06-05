using MediatR;

namespace Restaurant.Application.Commands
{
    public class DeleteDishCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
