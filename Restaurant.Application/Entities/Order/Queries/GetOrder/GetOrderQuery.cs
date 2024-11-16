using MediatR;

namespace Restaurant.Application.Entities.Order.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<OrderViewModel>
    {
        public required Guid Id { get; set; }
    }
}
