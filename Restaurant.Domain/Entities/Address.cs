namespace Restaurant.Domain.Entities
{
    public class Address : Entity
    {
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string BuildingNumber { get; set; }
        public required string ApartmentNumber { get; set; }
        public string? Entrance { get; set; }
        public required int Floor { get; set; }
        public required User User { get; set; }
        public Guid UserId { get; set; }
    }
}
