using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetDishByIdQuery : IRequest<DishDetails>
    {
        public required Guid Id { get; set; }
    }
}
