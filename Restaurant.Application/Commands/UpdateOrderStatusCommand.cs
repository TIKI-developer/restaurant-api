using MediatR;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Commands
{
    public class UpdateOrderStatusCommand : IRequest
    {
        public required Guid Id { get; set; }
        public OrderStatus? NewStatus { get; set; }
        public float? DeliveryCost { get; set; }
        public DateTime? ReceiptAt { get; set; }
    }
}
