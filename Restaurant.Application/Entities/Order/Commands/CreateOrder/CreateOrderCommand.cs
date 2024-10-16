using MediatR;
using Restaurant.Domain.Dish;
using Restaurant.Domain.User;

namespace Restaurant.Application.Entities.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public required Guid ClientId { get; set; }
        public required ICollection<Guid> Dishes { get; set; }
        public required DateTime CreationDateTime { get; set; }
    }
}
