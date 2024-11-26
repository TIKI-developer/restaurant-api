using MediatR;

namespace Restaurant.Application.Entities.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public required Guid UserId { get; set; }
        public required string Address { get; set; }
        public required int PersonQuantity { get; set; }
        public bool AddForks { get; set; }
        public bool AddChopsticks { get; set; }
    }
}
