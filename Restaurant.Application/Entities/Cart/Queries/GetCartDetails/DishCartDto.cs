using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Cart;

namespace Restaurant.Application.Entities.Dish.Queries.GetDishList
{
    public class DishCartDto : IMapWith<CartItem>
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required float Price { get; set; }
        public string? Image { get; set; }
        public required int Count { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartItem, DishCartDto>()
                .ForMember(dto => dto.Id, 
                opt => opt.MapFrom(cartDish => cartDish.Dish.Id))
                .ForMember(dto => dto.Name, 
                opt => opt.MapFrom(cartDish => cartDish.Dish.Name))
                .ForMember(dto => dto.Price, 
                opt => opt.MapFrom(cartDish => cartDish.Dish.Price))
                .ForMember(dto => dto.Image, 
                opt => opt.MapFrom(cartDish => cartDish.Dish.Images.FirstOrDefault()))
                .ForMember(dto => dto.Count, 
                opt => opt.MapFrom(cartDish => cartDish.Count));
        }
    }
}
