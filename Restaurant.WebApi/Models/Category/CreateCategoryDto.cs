using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Category.Commands.CreateCategory;

namespace Restaurant.WebApi.Models.Category
{
    public class CreateCategoryDto : IMapWith<CreateCategoryCommand>
    {
        public required string Name { get; set; }
        public byte[]? Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryDto, CreateCategoryCommand>()

                .ForMember(categoryVm => categoryVm.Name,
                    opt => opt.MapFrom(category => category.Name))

                .ForMember(categoryVm => categoryVm.Image,
                    opt => opt.MapFrom(category => category.Image));
        }
    }
}
