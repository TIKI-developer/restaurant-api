using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;

namespace Restaurant.WebApi.Models
{
    public class CreateContentDto : IMapWith<CreateContentCommand>
    {
        public bool? IsPublished { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContentDto, CreateContentCommand>();
        }
    }
}
