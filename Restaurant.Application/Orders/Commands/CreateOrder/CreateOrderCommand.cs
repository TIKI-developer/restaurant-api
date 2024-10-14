using MediatR;
using Restaurant.Domain;

namespace Restaurant.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public required Guid Id { get; set; }
        public required ICollection<Dish> Dishes { get; set; }
        public required DateTime CreationDateTime { get; set; }
        public required User Client { get; set; }
    }
}
