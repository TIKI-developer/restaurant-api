using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.ViewModels
{
    public class AddressDetails : IMapWith<Address>
    {
        public required Guid Id { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string BuildingNumber { get; set; }
        public required string ApartmentNumber { get; set; }
        public string? Entrance { get; set; }
        public required int Floor { get; set; }
        public required Guid UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressDetails>()
                .ForMember(to => to.UserId, opt => opt.MapFrom(from => from.User.Id));
        }
    }
}
