using MediatR;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Commands
{
    public class UpdateBranchCommand : IRequest
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public Address? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public Schedule? Schedule { get; set; }
        public ulong? AverageCookingTime { get; set; }
        public Content? Content { get; set; }
    }
}
