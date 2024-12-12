using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Category.Commands.Create;

namespace Restaurant.WebApi.Models.Category
{
    public class CreateCategoryDto : IMapWith<CreateCommand>
    {
        public required string Name { get; set; }
        public required string Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryDto, CreateCommand>();
        }
    }
}
