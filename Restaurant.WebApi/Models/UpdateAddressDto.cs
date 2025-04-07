using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;

namespace Restaurant.WebApi.Models
{
    public class UpdateAddressDto : IMapWith<UpdateAddressCommand>
    {
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? BuildingNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string? Entrance { get; set; }
        public int? Floor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAddressDto, UpdateAddressCommand>();
        }
    }
}
