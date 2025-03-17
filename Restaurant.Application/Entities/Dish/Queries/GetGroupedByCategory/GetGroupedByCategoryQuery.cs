using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Dish.Queries.GetGroupedByCategory
{
    public class GetGroupedByCategoryQuery : IRequest<DishListGroupedByCategory> { }
}
