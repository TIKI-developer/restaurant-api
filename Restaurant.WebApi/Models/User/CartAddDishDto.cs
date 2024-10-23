using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Cart.Commands.CartAddDish;

namespace Restaurant.WebApi.Models.User
{
    public class CartAddDishDto : IMapWith<CartAddDishCommand>
    {
        public required ICollection<Guid> NewDishes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartAddDishDto, CartAddDishCommand>()

                .ForMember(d => d.NewDishes,
                    opt => opt.MapFrom(dto => dto.NewDishes));

        }
    }
}
