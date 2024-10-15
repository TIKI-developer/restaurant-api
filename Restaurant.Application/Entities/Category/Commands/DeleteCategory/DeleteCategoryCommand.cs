using MediatR;


namespace Restaurant.Application.Entities.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
