using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain;

namespace Restaurant.Application.Categories.Queries.GetCategoryList
{
    public class CategoryLookupDto : IMapWith<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryLookupDto>()

                .ForMember(categoryDto => categoryDto.Id,
                    opt => opt.MapFrom(category => category.Id))

                .ForMember(categoryDto => categoryDto.Name,
                    opt => opt.MapFrom(category => category.Name))

                .ForMember(categoryDto => categoryDto.Image,
                    opt => opt.MapFrom(category => category.Image));
        }
    }
}
