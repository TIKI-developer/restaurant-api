using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Category;

namespace Restaurant.Application.Entities.Category.Queries.GetCategoryImage
{
    public class CategoryImageViewModel : IMapWith<CategoryModel>
    {
        public string? Image;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryModel, CategoryImageViewModel>()

                .ForMember(categoryVm => categoryVm.Image,
                    opt => opt.MapFrom(category => category.Image));
        }
    }
}
