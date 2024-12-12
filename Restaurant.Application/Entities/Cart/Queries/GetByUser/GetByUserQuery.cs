using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Cart.Queries.GetDetails
{
    public class GetByUserQuery : IRequest<CartDetails>
    {
        public required Guid UserId { get; set; }
    }
}
