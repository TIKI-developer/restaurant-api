using MediatR;

namespace Restaurant.Application.Commands
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string Image { get; set; }
        public CreateContentCommand? Content { get; set; }
    }
}
