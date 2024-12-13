using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Category.Commands.Create;
using Restaurant.WebApi.Models.Content;

namespace Restaurant.WebApi.Models.Category
{
    public class CreateCategoryDto : IMapWith<CreateCommand>
    {
        public required string Name { get; set; }
        public required string Image { get; set; }
        public required CreateContentDto Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryDto, CreateCommand>();
        }
    }
}
