using MediatR;

namespace Restaurant.Application.Entities.Category.Commands.Update
{
    public class UpdateCommand : IRequest<Unit>
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public Content.Commands.UpdateCommand? Content { get; set; }
    }
}
