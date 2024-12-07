using MediatR;

namespace Restaurant.Application.Entities.Cart.Queries.GetCartDetails
{
    public class GetCartDetailsQuery : IRequest<CartDetailsViewModel>
    {
        public required Guid UserId { get; set; }
    }
}
