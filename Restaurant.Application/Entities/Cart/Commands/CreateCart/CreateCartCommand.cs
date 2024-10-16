using MediatR;

namespace Restaurant.Application.Entities.Cart.Commands.CreateCart
{
    public class CreateCartCommand : IRequest
    {
        public required Guid ClientId { get; set; }
    }
}
