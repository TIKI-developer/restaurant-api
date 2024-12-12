using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Cart.Commands.DeleteDish;

namespace Restaurant.WebApi.Models.Cart
{
    public class CartDeleteDishDto : IMapWith<DeleteDishCommand>
    {
        public Guid DishId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartDeleteDishDto, DeleteDishCommand>();
        }
    }
}
