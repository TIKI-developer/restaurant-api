using MediatR;

namespace Restaurant.Application.Entities.Address.Commands.AddAddress
{
    public class AddAddressCommand : IRequest<Guid>
    {
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string BuildingNumber { get; set; }
        public required string ApartmentNumber { get; set; }
        public string? Entrance { get; set; }
        public required int Floor { get; set; }
        public required Guid UserId { get; set; }
    }
}
