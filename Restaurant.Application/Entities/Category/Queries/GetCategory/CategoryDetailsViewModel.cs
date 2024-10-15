using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Category;

namespace Restaurant.Application.Entities.Category.Queries.GetCategory
{
    public class CategoryDetailsViewModel : IMapWith<CategoryModel>
    {
        public required string Name { get; set; }
        public byte[]? Image {  get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryModel, CategoryDetailsViewModel>()

                .ForMember(categoryVm => categoryVm.Name,
                    opt => opt.MapFrom(category => category.Name))

                .ForMember(categoryVm => categoryVm.Image,
                    opt => opt.MapFrom(category => category.Image));
        }
    }
}
