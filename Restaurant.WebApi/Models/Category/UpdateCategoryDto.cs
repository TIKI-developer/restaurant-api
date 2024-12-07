using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Category.Commands.UpdateCategory;

namespace Restaurant.WebApi.Models.Category
{
    public class UpdateCategoryDto : IMapWith<UpdateCategoryCommand>
    {
        public string? Name { get; set; }
        public string? Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCategoryDto, UpdateCategoryCommand>();
        }
    }
}
