using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetOrderByUserQuery : IRequest<OrderList>
    {
        public required Guid UserId { get; set; }
    }
}
