using AutoMapper;
using Restaurant.Application.Categories.Commands.UpdateCategory;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Dishes.Commands.UpdateDish;

namespace Restaurant.WebApi.Models
{
    public class UpdateCategoryDto : IMapWith<UpdateCategoryCommand>
    {
        public string Name { get; set; } 
        public byte[] Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDishDto, UpdateDishCommand>()

                .ForMember(categoryVm => categoryVm.Name,
                    opt => opt.MapFrom(category => category.Name))

                .ForMember(categoryVm => categoryVm.Image,
                    opt => opt.MapFrom(category => category.Image));
        }
    }
}
