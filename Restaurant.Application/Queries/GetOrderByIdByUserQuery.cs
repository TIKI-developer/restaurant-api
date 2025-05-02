using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetOrderByIdByUserQuery : IRequest<OrderDetails>
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
    }
}
