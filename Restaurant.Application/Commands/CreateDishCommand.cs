using MediatR;

namespace Restaurant.Application.Commands
{
    public class CreateDishCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required float Price { get; set; }
        public required string Image { get; set; }
        public required float Weight { get; set; }
        public required CreateContentCommand Content { get; set; }
        public ICollection<Guid>? Categories { get; set; } = [];
    }
}
