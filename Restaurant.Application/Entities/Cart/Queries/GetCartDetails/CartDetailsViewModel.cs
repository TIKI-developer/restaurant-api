using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Dish;
using Restaurant.Domain.User.Client;

namespace Restaurant.Application.Entities.Cart.Queries.GetCartDetails
{
    public class CartDetailsViewModel : IMapWith<ClientModel.CartModel>
    {
        public ICollection<DishModel>? Dishes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ClientModel.CartModel, CartDetailsViewModel>()

                .ForMember(cartVm => cartVm.Dishes,
                    opt => opt.MapFrom(cart => cart.Dishes));
        }
    }
}
