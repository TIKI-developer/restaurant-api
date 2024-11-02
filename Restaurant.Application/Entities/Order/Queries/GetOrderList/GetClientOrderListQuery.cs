using MediatR;

namespace Restaurant.Application.Entities.Order.Queries.GetOrderList
{
    public class GetClientOrderListQuery : IRequest<OrderListViewModel>
    {
        public required Guid ClientId { get; set; }
    }
}
