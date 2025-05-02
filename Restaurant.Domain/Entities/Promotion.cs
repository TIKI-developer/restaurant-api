using Restaurant.Domain.ValueObjects;

namespace Restaurant.Domain.Entities
{
    public class Promotion : Entity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required bool IsAdvanced { get; set; }
        public required Content Content { get; set; }
    }
}
