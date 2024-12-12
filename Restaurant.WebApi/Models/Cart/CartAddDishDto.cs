using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Cart.Commands.AddDish;

namespace Restaurant.WebApi.Models.Cart
{
    public class CartAddDishDto : IMapWith<AddDishCommand>
    {
        public required Guid DishId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartAddDishDto, AddDishCommand>();
        }
    }
}
