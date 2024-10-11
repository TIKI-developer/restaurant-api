using AutoMapper;
using Restaurant.Application.Categories.Commands.CreateCategory;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Dishes.Commands.CreateDish;

namespace Restaurant.WebApi.Models
{
    public class CreateCategoryDto : IMapWith<CreateCategoryCommand>
    {
        public required string Name { get; set; }
        public byte[]? Image {  get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryDto, CreateDishCommand>()

                .ForMember(categoryVm => categoryVm.Name,
                    opt => opt.MapFrom(category => category.Name))

                .ForMember(categoryVm => categoryVm.Image,
                    opt => opt.MapFrom(category => category.Image));
        }
    }
}
