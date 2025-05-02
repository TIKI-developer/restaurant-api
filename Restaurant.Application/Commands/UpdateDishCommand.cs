using MediatR;

namespace Restaurant.Application.Commands
{
    public class UpdateDishCommand : IRequest
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public string? Image { get; set; }
        public float? Weight { get; set; }
        public UpdateContentCommand? Content { get; set; }
        public ICollection<Guid>? Categories { get; set; } = [];
    }
}
