using MediatR;

namespace Restaurant.Application.Entities.Order.Queries.GetOrderList
{
    public class GetOrderListQuery : IRequest<OrderListViewModel> { }
}
