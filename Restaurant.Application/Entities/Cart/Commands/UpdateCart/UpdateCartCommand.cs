using MediatR;
using Restaurant.Domain.Dish;

namespace Restaurant.Application.Entities.Cart.Commands.UpdateCart
{
    public class UpdateCartCommand : IRequest
    {
        public required Guid ClientId { get; set; }
        public required ICollection<DishModel> Dishes { get; set; }
    }
}
