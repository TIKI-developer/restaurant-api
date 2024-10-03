using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain;


namespace Restaurant.Application.Dishes.Queries.GetDishList
{
    public class DishLookupDto : IMapWith<Dish>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dish, DishLookupDto>()

                .ForMember(dishDto => dishDto.Id,
                    opt => opt.MapFrom(dish => dish.Id))

                .ForMember(dishDto => dishDto.Name,
                    opt => opt.MapFrom(dish => dish.Name));
        }
    }
}
