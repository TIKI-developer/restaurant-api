using MediatR;
using Restaurant.Domain.Order;

namespace Restaurant.Application.Entities.Order.Commands.UpdateOrderStatus
{
    public class UpdateOrderStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}
