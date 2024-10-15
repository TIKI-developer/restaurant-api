using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Cart;
using Restaurant.Domain.Dish;

namespace Restaurant.Application.Entities.Cart.Queries.GetCartDetails
{
    public class CartDetailsViewModel : IMapWith<CartModel>
    {
        public ICollection<DishModel>? Dishes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartModel, CartDetailsViewModel>()

                .ForMember(cartVm => cartVm.Dishes,
                    opt => opt.MapFrom(cart => cart.Dishes));
        }
    }
}
