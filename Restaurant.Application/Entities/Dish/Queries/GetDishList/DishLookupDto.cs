using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Dish;


namespace Restaurant.Application.Entities.Dish.Queries.GetDishList
{
    public class DishLookupDto : IMapWith<DishModel>
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required float Price { get; set; }
        public string? Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DishModel, DishLookupDto>()

                .ForMember(dishDto => dishDto.Id,
                    opt => opt.MapFrom(dish => dish.Id))

                .ForMember(dishDto => dishDto.Name,
                    opt => opt.MapFrom(dish => dish.Name))

                .ForMember(dishDto => dishDto.Price,
                    opt => opt.MapFrom(dish => dish.Price))

                .ForMember(dishDto => dishDto.Image,
                    opt => opt.MapFrom(dish => dish.Images.FirstOrDefault()));
        }
    }
}
