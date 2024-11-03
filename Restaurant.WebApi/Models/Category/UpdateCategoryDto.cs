using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Category.Commands.UpdateCategory;

namespace Restaurant.WebApi.Models.Category
{
    public class UpdateCategoryDto : IMapWith<UpdateCategoryCommand>
    {
        public string? Name { get; set; }
        public IFormFile? Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCategoryDto, UpdateCategoryCommand>()

                .ForMember(categoryVm => categoryVm.Name,
                    opt => opt.MapFrom(category => category.Name))

                .ForMember(categoryVm => categoryVm.Image,
                    opt => opt.MapFrom(category => category.Image));
        }
    }
}
