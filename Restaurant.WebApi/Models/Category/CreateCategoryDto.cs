using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Category.Commands.CreateCategory;

namespace Restaurant.WebApi.Models.Category
{
    public class CreateCategoryDto : IMapWith<CreateCategoryCommand>
    {
        public required string Name { get; set; }
        public required string Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryDto, CreateCategoryCommand>();
        }
    }
}
