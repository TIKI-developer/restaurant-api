using MediatR;

namespace Restaurant.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
