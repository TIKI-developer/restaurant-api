using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;

namespace Restaurant.WebApi.Models
{
    public class UpdateCategoryDto : IMapWith<UpdateCategoryCommand>
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public UpdateContentDto? Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCategoryDto, UpdateCategoryCommand>();
        }
    }
}
