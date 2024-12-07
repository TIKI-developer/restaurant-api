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
        public required string Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DishModel, DishLookupDto>();
        }
    }
}
