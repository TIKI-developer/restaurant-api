using MediatR;
using Restaurant.Domain;

namespace Restaurant.Application.Entities.Order.Commands.UpdateStatus
{
    public class UpdateStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}
