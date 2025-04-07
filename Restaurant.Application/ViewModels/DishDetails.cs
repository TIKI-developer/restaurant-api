using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.ViewModels
{
    public class DishDetails : IMapWith<Dish>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required float Price { get; set; }
        public required float Weight { get; set; }
        public required Timestamps Timestamps { get; set; }
        public required Content Content { get; set; }
        public ICollection<Guid>? Categories { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Dish, DishDetails>()

                .ForMember(to => to.Categories,
                    opt => opt.MapFrom(from => from.Categories.Select(c => c.Id)));
        }
    }
}