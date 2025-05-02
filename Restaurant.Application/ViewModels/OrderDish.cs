using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.ViewModels
{
    public class OrderDish : IMapWith<Dish>
    {
        public required string Name { get; set; }
        public required float Price { get; set; }
        public required string Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dish, OrderDish>();
        }
    }
}
