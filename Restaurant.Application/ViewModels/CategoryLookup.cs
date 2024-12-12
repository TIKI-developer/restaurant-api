using Restaurant.Application.Common.Mappings;
using Restaurant.Domain;

namespace Restaurant.Application.ViewModels
{
    public class CategoryLookup : IMapWith<Category>
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Image { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Category, CategoryLookup>();
        }
    }
}
