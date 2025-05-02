using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetCartByUserQuery : IRequest<CartDetails>
    {
        public required Guid UserId { get; set; }
    }
}
