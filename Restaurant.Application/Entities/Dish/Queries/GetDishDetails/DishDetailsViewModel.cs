using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Dish;

namespace Restaurant.Application.Entities.Dish.Queries.GetDishDetails
{
    public class DishDetailsViewModel : IMapWith<DishModel>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required float Price { get; set; }
        public required string Image { get; set; }
        public ICollection<Guid>? Categories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DishModel, DishDetailsViewModel>()

                .ForMember(dishVm => dishVm.Categories,
                    opt => opt.MapFrom(dish => dish.Categories.Select(c => c.Id)));
        }
    }
}