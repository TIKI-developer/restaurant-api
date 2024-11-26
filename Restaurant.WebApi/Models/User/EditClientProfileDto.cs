using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.User.Commands.EditProfile;

namespace Restaurant.WebApi.Models.User
{
    public class EditClientProfileDto : IMapWith<EditProfileCommand>
    {
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditClientProfileDto, EditProfileCommand>();
        }
    }
}