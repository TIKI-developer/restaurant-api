using MediatR;


namespace Restaurant.Application.Entities.Order.Queries.GetClientOrderList
{
    public class GetClientOrderListQuery : IRequest<OrderListViewModel>
    {
        public required Guid ClientId { get; set; }
    }
}
