using MediatR;

namespace Restaurant.Application.Entities.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
    }
}
