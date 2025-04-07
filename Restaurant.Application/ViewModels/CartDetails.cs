using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Models;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.ViewModels
{
    public class CartDetails : IMapWith<Cart>
    {
        public ICollection<CartItemDto>? Dishes { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Cart, CartDetails>()
                .ForMember(to => to.Dishes,
                    opt => opt.MapFrom(from => from.Items));
        }
    }
}
