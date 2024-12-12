using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Order.Queries.GetById
{
    public class GetByIdQuery : IRequest<OrderDetails>
    {
        public required Guid Id { get; set; }
    }
}
