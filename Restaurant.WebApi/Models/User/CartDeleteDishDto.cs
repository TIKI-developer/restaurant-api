using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Cart.Commands.CartDeleteDish;

namespace Restaurant.WebApi.Models.User
{
    public class CartDeleteDishDto : IMapWith<CartDeleteDishCommand>
    {
        public Guid DishId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartDeleteDishDto, CartDeleteDishCommand>();
        }
    }
}
