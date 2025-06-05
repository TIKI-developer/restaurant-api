using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetDishListByCategoryQuery : IRequest<DishList>
    {
        public Guid CategoryId { get; set; }
    }
}
