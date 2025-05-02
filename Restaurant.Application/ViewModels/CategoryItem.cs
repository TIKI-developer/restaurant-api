using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.ViewModels
{
    public class CategoryItem : IMapWith<Category>
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Image { get; set; }
        public required Timestamps Timestamps { get; set; }
        public required Content Content { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Category, CategoryItem>();
        }
    }
}
