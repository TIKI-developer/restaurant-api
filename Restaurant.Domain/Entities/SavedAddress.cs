using Restaurant.Domain.ValueObjects;

namespace Restaurant.Domain.Entities
{
    public class SavedAddress : Entity
    {
        public required string Name { get; set; }
        public required Address Address { get; set; }
        public required User User { get; set; }
        public Guid UserId { get; set; }
    }
}
