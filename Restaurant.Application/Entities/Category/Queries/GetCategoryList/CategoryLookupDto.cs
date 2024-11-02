using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Category;

namespace Restaurant.Application.Entities.Category.Queries.GetCategoryList
{
    public class CategoryLookupDto : IMapWith<CategoryModel>
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryModel, CategoryLookupDto>()

                .ForMember(categoryDto => categoryDto.Id,
                    opt => opt.MapFrom(category => category.Id))

                .ForMember(categoryDto => categoryDto.Name,
                    opt => opt.MapFrom(category => category.Name))

                .ForMember(categoryDto => categoryDto.Image,
                    opt => opt.MapFrom(category => category.Image));
        }
    }
}
