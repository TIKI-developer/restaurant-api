using MediatR;
using Restaurant.Domain;

namespace Restaurant.Application.Entities.Order.Commands.Create
{
    public class CreateCommand : IRequest<Guid>
    {
        public required Guid UserId { get; set; }
        public Address? Address { get; set; }
        public required int PersonQuantity { get; set; }
        public required bool AddForks { get; set; }
        public required bool AddChopsticks { get; set; }
        public required PaymentMethod PaymentMethod { get; set; }
    }
}
