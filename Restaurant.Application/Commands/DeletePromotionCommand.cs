using MediatR;

namespace Restaurant.Application.Commands
{
    public class DeletePromotionCommand : IRequest<Unit>
    {
        public required Guid Id { get; set; }
    }
}
