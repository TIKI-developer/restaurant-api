using MediatR;

namespace Restaurant.Application.Entities.Order.Queries.GetOrder
{
    public class GetOrderDetailsByUserQuery : IRequest<OrderViewModel>
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
    }
}
