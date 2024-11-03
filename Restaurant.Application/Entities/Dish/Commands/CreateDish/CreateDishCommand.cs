using MediatR;

namespace Restaurant.Application.Entities.Dish.Commands.CreateDish
{
    public class CreateDishCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required float Price { get; set; }
        public List<string> Images { get; set; } = [];
        public ICollection<Guid>? Categories { get; set; }
    }
}
