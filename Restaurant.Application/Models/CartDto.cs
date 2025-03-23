using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Models.Cart
{
    public class CartDto : ICart, IMapWith<Domain.Cart>
    {
        public required ICollection<CartItemDto> Items { get; set; }

        public class CartItemDto : IMapWith<Domain.CartItem>
        {
            public required Guid DishId { get; set; }
            public required int Count { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Domain.CartItem, CartItemDto>();
            }
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Cart, CartDto>();
        }
    }
}
