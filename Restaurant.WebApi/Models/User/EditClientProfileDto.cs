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
            profile.CreateMap<EditClientProfileDto, EditProfileCommand>()

                .ForMember(p => p.Name,
                    opt => opt.MapFrom(pDto => pDto.Name))
                .ForMember(p => p.Number,
                    opt => opt.MapFrom(pDto => pDto.Number))
                .ForMember(p => p.Address,
                    opt => opt.MapFrom(pDto => pDto.Address));

        }
    }
}