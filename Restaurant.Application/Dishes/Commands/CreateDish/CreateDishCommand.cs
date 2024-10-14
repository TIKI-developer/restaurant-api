using MediatR;
using Restaurant.Domain;

namespace Restaurant.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommand : IRequest<Guid>
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required float Price { get; set; }
        public byte[]? Image { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
