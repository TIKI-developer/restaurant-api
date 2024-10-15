using MediatR;
using Restaurant.Domain.Category;

namespace Restaurant.Application.Entities.Dish.Commands.CreateDish
{
    public class CreateDishCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required float Price { get; set; }
        public byte[]? Image { get; set; }
        public ICollection<CategoryModel>? Categories { get; set; }
    }
}
