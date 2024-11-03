using MediatR;
using Restaurant.Application.Entities.Dish.Queries.GetDishImage;

namespace Restaurant.Application.Entities.Dish.Queries.GetDishImageQuery
{
    public class GetDishImageQuery : IRequest<DishImagesViewModel>
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
