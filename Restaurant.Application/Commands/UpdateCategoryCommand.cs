using MediatR;

namespace Restaurant.Application.Commands
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public UpdateContentCommand? Content { get; set; }
    }
}
