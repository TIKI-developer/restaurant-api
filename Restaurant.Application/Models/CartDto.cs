using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Models.Cart
{
    public class CartDto : ICart, IMapWith<Domain.Entities.Cart>
    {
        public required ICollection<CartItemDto> Items { get; set; }

        public class CartItemDto : IMapWith<CartItem>
        {
            public required Guid DishId { get; set; }
            public required int Count { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<CartItem, CartItemDto>();
            }
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Cart, CartDto>();
        }
    }
}
