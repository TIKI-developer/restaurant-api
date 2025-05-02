using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;

namespace Restaurant.WebApi.Models
{
    public class UserLoginDto : IMapWith<LoginCommand>
    {
        public string? Name { get; set; }
        public required string PhoneNumber { get; set; }
        public string? FncToken { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserLoginDto, LoginCommand>();
        }
    }
}
