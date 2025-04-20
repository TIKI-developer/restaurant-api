using MediatR;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Commands
{
    public class CreateBranchCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required bool IsActive { get; set; }
        public required Address Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required Schedule Schedule { get; set; }
        public required ulong AverageCookingTime { get; set; }
        public required Content Content { get; set; }
    }
}
