using Restaurant.Application.Common.Mappings;
using Restaurant.Domain;

namespace Restaurant.Application.ViewModels
{
    public class DishLookup : IMapWith<Dish>
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required float Price { get; set; }
        public required string Image { get; set; }
        public required Timestamps Timestamps { get; set; }
        public required Content Content { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Dish, DishLookup>();
        }
    }
}
