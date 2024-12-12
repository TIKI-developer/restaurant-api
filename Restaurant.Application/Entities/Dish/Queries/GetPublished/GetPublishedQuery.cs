using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Dish.Queries.GetPublished
{
    public class GetPublishedQuery : IRequest<DishList> { }
}
