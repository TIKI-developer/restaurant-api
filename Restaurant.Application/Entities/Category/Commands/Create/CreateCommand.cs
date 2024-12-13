using MediatR;

namespace Restaurant.Application.Entities.Category.Commands.Create
{
    public class CreateCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string Image { get; set; }
        public Content.Commands.CreateCommand? Content { get; set; }
    }
}
