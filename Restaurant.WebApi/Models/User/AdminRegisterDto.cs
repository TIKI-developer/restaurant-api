using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.User.Commands.RegisterAdmin;


namespace Restaurant.WebApi.Models.User
{
    public class AdminRegisterDto : IMapWith<RegisterAdminCommand>
    {
        public required string Number { get; set; }
        public required string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<AdminRegisterDto, RegisterAdminCommand>()

                    .ForMember(user => user.Number,
                        opt => opt.MapFrom(userDto => userDto.Number))

                    .ForMember(user => user.Password,
                        opt => opt.MapFrom(userDto => userDto.Password));
        }
    }
}
