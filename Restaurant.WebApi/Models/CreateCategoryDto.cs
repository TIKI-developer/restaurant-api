using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;

namespace Restaurant.WebApi.Models
{
    public class CreateCategoryDto : IMapWith<CreateCategoryCommand>
    {
        public required string Name { get; set; }
        public required string Image { get; set; }
        public required CreateContentDto Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryDto, CreateCategoryCommand>();
        }
    }
}
