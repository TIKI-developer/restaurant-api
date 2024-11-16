using MediatR;

namespace Restaurant.Application.Entities.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public required Guid ClientId { get; set; }
        public required string Address { get; set; }
    }
}
