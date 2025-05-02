using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;

namespace Restaurant.WebApi.Models
{
    public class UpdateUserDefaultAddressDto : IMapWith<UpdateUserDefaultAddressCommand>
    {
        public required Guid DefaultAddressId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDefaultAddressDto, UpdateUserDefaultAddressCommand>();
        }
    }
}
