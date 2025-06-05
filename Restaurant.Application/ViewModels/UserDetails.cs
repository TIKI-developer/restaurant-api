using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.ViewModels
{
    public class UserDetails : IMapWith<User>
    {
        public string? Name { get; set; }
        public required string PhoneNumber { get; set; }
        public Guid? DefaultAddressId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetails>()

                .ForMember(to => to.Name,
                    opt => opt.MapFrom(from => from.Profile.Name));
        }
    }
}
