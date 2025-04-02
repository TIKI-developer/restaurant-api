using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.User.Commands.Update;
using Restaurant.Domain;

namespace Restaurant.WebApi.Models.User
{
    public class UpdateUserDto : IMapWith<UpdateCommand>
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid? DefaultAddressId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateCommand>();
        }
    }
}