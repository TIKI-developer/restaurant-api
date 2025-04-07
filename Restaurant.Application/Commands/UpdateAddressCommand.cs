using MediatR;

namespace Restaurant.Application.Commands
{
    public class UpdateAddressCommand : IRequest
    {
        public required Guid Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? BuildingNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string? Entrance { get; set; }
        public int? Floor { get; set; }
    }
}
