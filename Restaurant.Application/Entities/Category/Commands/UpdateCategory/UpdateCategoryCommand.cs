using MediatR;

namespace Restaurant.Application.Entities.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
    }
}
