using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.User.Commands.RegisterClient;

namespace Restaurant.WebApi.Models.User
{
    public class ClientRegisterDto : IMapWith<RegisterClientCommand>
    {
        public string? Name { get; set; }
        public required string Number { get; set; }
        public required string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<ClientRegisterDto, RegisterClientCommand>()

                    .ForMember(user => user.Name,
                        opt => opt.MapFrom(userDto => userDto.Name))

                    .ForMember(user => user.Number,
                        opt => opt.MapFrom(userDto => userDto.Number))

                    .ForMember(user => user.Password,
                        opt => opt.MapFrom(userDto => userDto.Password));
        }
    }
}
