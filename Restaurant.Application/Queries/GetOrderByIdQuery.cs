using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDetails>
    {
        public required Guid Id { get; set; }
    }
}
