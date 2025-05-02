using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;

namespace Restaurant.WebApi.Models
{
    public class CartDeleteDishDto : IMapWith<DeleteDishFromCartCommand>
    {
        public Guid DishId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartDeleteDishDto, DeleteDishFromCartCommand>();
        }
    }
}
