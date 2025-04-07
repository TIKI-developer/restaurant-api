using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.ViewModels
{
    public class CartItemLookup : IMapWith<CartItem>
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required float Price { get; set; }
        public required string Image { get; set; }
        public required int Count { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<CartItem, CartItemLookup>()
                .ForMember(dto => dto.Id,
                opt => opt.MapFrom(cartDish => cartDish.Dish.Id))
                .ForMember(dto => dto.Name,
                opt => opt.MapFrom(cartDish => cartDish.Dish.Name))
                .ForMember(dto => dto.Image,
                opt => opt.MapFrom(cartDish => cartDish.Dish.Image))
                .ForMember(dto => dto.Price,
                opt => opt.MapFrom(cartDish => cartDish.Dish.Price));

        }
    }
}
