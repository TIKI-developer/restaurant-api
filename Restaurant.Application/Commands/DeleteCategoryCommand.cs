using MediatR;


namespace Restaurant.Application.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
