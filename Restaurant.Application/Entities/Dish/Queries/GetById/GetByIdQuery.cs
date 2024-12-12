using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Dish.Queries.GetById
{
    public class GetByIdQuery : IRequest<DishDetails>
    {
        public required Guid Id { get; set; }
    }
}
