using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Content.Commands;

namespace Restaurant.WebApi.Models.Content
{
    public class CreateContentDto : IMapWith<CreateCommand>
    {
        public bool? IsPublished { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContentDto, CreateCommand>();
        }
    }
}
