using MediatR;

namespace Restaurant.Application.Entities.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string Image { get; set; }
    }
}
