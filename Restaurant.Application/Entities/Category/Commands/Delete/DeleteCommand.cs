using MediatR;


namespace Restaurant.Application.Entities.Category.Commands.Delete
{
    public class DeleteCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
