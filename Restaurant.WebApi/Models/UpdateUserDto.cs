using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;

namespace Restaurant.WebApi.Models
{
    public class UpdateUserDto : IMapWith<UpdateUserProfileCommand>
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid? DefaultAddressId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateUserProfileCommand>();
        }
    }
}