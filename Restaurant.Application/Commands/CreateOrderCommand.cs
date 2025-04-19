using MediatR;
using Restaurant.Application.Models.Cart;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public required Guid UserId { get; set; }
        public required ReceiptMethod ReceiptMethod { get; set; }
        public Address? Address { get; set; }
        public required int PersonQuantity { get; set; }
        public required bool AddForks { get; set; }
        public required bool AddChopsticks { get; set; }
        public string? Comment { get; set; }
        public required DateTime ReceiptAt { get; set; }
        public required PaymentMethod PaymentMethod { get; set; }
        public CartDto? Cart { get; set; }
    }
}
