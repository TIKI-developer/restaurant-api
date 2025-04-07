using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;

namespace Restaurant.WebApi.Models
{
    public class AddAddressDto : IMapWith<AddAddressCommand>
    {
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string BuildingNumber { get; set; }
        public required string ApartmentNumber { get; set; }
        public string? Entrance { get; set; }
        public required int Floor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddAddressDto, AddAddressCommand>();
        }
    }
}
