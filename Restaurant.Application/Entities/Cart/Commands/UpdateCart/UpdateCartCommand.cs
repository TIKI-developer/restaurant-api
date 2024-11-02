using MediatR;

namespace Restaurant.Application.Entities.Cart.Commands.UpdateCart
{
    public class UpdateCartCommand : IRequest
    {
        public required Guid ClientId { get; set; }
        public required ICollection<Guid> Dishes { get; set; }
    }
}
