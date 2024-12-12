using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Order.Queries.GetByUser
{
    public class GetByUserQuery : IRequest<OrderList>
    {
        public required Guid UserId { get; set; }
    }
}
