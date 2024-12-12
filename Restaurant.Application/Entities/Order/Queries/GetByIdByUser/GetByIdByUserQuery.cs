using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Order.Queries.GetByIdByUser
{
    public class GetByIdByUserQuery : IRequest<OrderDetails>
    {
        public required Guid Id { get; set; }
        public required Guid UserId { get; set; }
    }
}
