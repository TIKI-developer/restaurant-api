using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain;

namespace Restaurant.Application.Users.Queries.GetUserDetails
{
    public class UserDetailsViewModel : IMapWith<User>
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public required string Number { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsViewModel>()
                .ForMember(userVm => userVm.Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.Name,
                    opt => opt.MapFrom(user => user.Name))
                .ForMember(userVm => userVm.Number,
                    opt => opt.MapFrom(user => user.Number));
        }
    }
}
