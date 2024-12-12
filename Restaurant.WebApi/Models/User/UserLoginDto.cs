using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.User.Commands.Login;

namespace Restaurant.WebApi.Models.User
{
    public class UserLoginDto : IMapWith<LoginCommand>
    {
        public string? Name { get; set; }
        public required string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserLoginDto, LoginCommand>();
        }
    }
}
