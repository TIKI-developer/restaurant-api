using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Category.Commands.Update;
using Restaurant.WebApi.Models.Content;

namespace Restaurant.WebApi.Models.Category
{
    public class UpdateCategoryDto : IMapWith<UpdateCommand>
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public UpdateContentDto? Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCategoryDto, UpdateCommand>();
        }
    }
}
