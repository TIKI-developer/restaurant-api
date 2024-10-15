using MediatR;
using Restaurant.Domain.Category;

namespace Restaurant.Application.Entities.Dish.Commands.UpdateDish
{
    public class UpdateDishCommand : IRequest
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public byte[]? Image { get; set; }
        public ICollection<CategoryModel>? Categories { get; set; }
    }
}
