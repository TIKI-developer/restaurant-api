using MediatR;

namespace Restaurant.Application.Entities.Dish.Commands.Update
{
    public class UpdateCommand : IRequest
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public string? Image { get; set; }
        public Content.Commands.UpdateCommand? Content { get; set; }
        public ICollection<Guid>? Categories { get; set; } = [];
    }
}
