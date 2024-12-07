using MediatR;

namespace Restaurant.Application.Entities.Order.Queries.GetOrderList
{
    public class GetUserOrderListQuery : IRequest<OrderListViewModel>
    {
        public required Guid UserId { get; set; }
    }
}
