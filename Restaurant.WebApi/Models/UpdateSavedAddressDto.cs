using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.WebApi.Models
{
    public class UpdateSavedAddressDto : IMapWith<UpdateSavedAddressCommand>
    {
        public required string Name { get; set; }
        public required Address Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSavedAddressDto, UpdateSavedAddressCommand>();
        }
    }
}
