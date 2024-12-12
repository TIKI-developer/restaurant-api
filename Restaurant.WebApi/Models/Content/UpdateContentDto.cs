using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Content.Commands;

namespace Restaurant.WebApi.Models.Content
{
    public class UpdateContentDto : IMapWith<UpdateCommand>
    {
        public bool? IsPublished { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContentDto, UpdateCommand>();
        }
    }
}
