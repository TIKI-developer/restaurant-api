using MediatR;


namespace Restaurant.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
