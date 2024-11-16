using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Dish.Queries.GetDishList;
using Restaurant.Domain.Cart;
using Restaurant.Domain.Dish;


namespace Restaurant.Application.Entities.Cart.Queries.GetCartDetails
{
    public class CartDetailsViewModel : IMapWith<CartModel>
    {
        public ICollection<DishCartDto>? Dishes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartModel, CartDetailsViewModel>()
                .ForMember(cartVm => cartVm.Dishes,
                    opt => opt.MapFrom(cart => cart.CartModelDishModels));
        }
    }
}
