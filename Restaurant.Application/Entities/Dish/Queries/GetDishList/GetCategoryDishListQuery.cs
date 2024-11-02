using MediatR;

namespace Restaurant.Application.Entities.Dish.Queries.GetDishList
{
    public class GetCategoryDishListQuery : IRequest<DishListViewModel>
    {
        public Guid CategoryId { get; set; }
    }
}
