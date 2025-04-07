using AutoMapper;
using Restaurant.Application.Common.Mappings;

namespace Restaurant.WebApi.Models
{
    public class CartBodyDto : IMapWith<Application.Models.Cart.CartDto>
    {
        public required ICollection<CartBodyItemDto> Items { get; set; } = [];

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartBodyDto, Application.Models.Cart.CartDto>()
                .ForMember(to => to.Items, opt => opt.MapFrom(from => from.Items));
        }
    }

    public class CartBodyItemDto : IMapWith<Application.Models.Cart.CartDto.CartItemDto>
    {
        public required Guid DishId { get; set; }
        public required int Count { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartBodyItemDto, Application.Models.Cart.CartDto.CartItemDto>();
        }
    }
}
