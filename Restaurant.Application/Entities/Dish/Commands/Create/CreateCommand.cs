using MediatR;

namespace Restaurant.Application.Entities.Dish.Commands.Create
{
    public class CreateCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required float Price { get; set; }
        public required string Image { get; set; }
        public required float Weight { get; set; }
        public required Content.Commands.CreateCommand Content { get; set; }
        public ICollection<Guid>? Categories { get; set; } = [];
    }
}
