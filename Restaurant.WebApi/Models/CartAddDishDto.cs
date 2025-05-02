using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;

namespace Restaurant.WebApi.Models
{
    public class CartAddDishDto : IMapWith<AddDishToCartCommand>
    {
        public required Guid DishId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartAddDishDto, AddDishToCartCommand>();
        }
    }
}
