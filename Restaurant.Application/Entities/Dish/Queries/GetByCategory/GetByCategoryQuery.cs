using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Dish.Queries.GetByCategory
{
    public class GetByCategoryQuery : IRequest<DishList>
    {
        public Guid CategoryId { get; set; }
    }
}
