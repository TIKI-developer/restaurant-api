using Restaurant.Domain.ValueObjects;

namespace Restaurant.Domain.Entities
{
    public class Verification
    {
        public required string Number { get; set; }
        public string? CheckId { get; set; }
        public required bool CanLogin { get; set; }
        public required Timestamps Timestamps { get; set; }
    }
}
