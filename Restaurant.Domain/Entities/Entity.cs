using Restaurant.Domain.ValueObjects;

namespace Restaurant.Domain.Entities
{
    public class Entity
    {
        public required Guid Id { get; set; }
        public required Timestamps Timestamps { get; set; }
    }
}
