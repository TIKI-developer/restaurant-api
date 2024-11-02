using MediatR;

namespace Restaurant.Application.Entities.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public string? Image { get; set; }
    }
}
