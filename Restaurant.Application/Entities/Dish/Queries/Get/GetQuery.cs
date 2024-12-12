using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Dish.Queries.Get
{
    public class GetQuery : IRequest<DishList> { }
}
