using Restaurant.Domain.ValueObjects;

namespace Restaurant.Domain.Entities
{
    public class Branch : Entity
    {
        public required string Name { get; set; }
        public required bool IsActive { get; set; }
        public required Address Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required Schedule Schedule { get; set; }
        public required ulong AverageCookingTime { get; set; }
        public required Content Content { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
