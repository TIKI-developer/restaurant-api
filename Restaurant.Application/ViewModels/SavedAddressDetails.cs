using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.ViewModels
{
    public class SavedAddressDetails : IMapWith<SavedAddress>
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required Address Address { get; set; }
        public required Guid UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SavedAddress, SavedAddressDetails>()
                .ForMember(to => to.UserId, opt => opt.MapFrom(from => from.User.Id));
        }
    }
}
