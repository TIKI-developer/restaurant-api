using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Category;

namespace Restaurant.Application.Entities.Category.Queries.GetCategory
{
    public class CategoryDetailsViewModel : IMapWith<CategoryModel>
    {
        public required string Name { get; set; }
        public required string Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryModel, CategoryDetailsViewModel>();
        }
    }
}
