using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.User;

namespace Restaurant.Application.Entities.User.Queries.GetUserDetails
{
    public class UserDetailsViewModel : IMapWith<UserModel>
    {
        public string? Name { get; set; }
        public required string Number { get; set; }
        public string? Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserModel, UserDetailsViewModel>()

                .ForMember(userVm => userVm.Name,
                    opt => opt.MapFrom(user => user.Profile.Name))
                .ForMember(userVm => userVm.Address,
                    opt => opt.MapFrom(user => user.Profile.Address));
        }
    }
}
