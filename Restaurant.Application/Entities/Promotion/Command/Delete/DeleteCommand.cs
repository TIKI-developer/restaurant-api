using MediatR;

namespace Restaurant.Application.Entities.Promotion.Command.Delete
{
    public class DeleteCommand : IRequest<Unit>
    {
        public required Guid Id { get; set; }
    }
}
