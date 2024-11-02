using MediatR;

namespace Restaurant.Application.Entities.Dish.Queries.GetDishDetails
{
    public class GetDishDetailsQuery : IRequest<DishDetailsViewModel>
    {
        public required Guid Id { get; set; }
    }
}
