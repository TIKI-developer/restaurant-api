namespace Restaurant.Domain
{
    public class Address
    {
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string BuildingNumber { get; set; }
        public required string ApartmentNumber { get; set; }
        public string? Entrance { get; set; }
    }
}
