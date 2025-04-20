using MediatR;

namespace Restaurant.Application.Commands
{
    public class DeleteBranchCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
