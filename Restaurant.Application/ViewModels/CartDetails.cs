using Restaurant.Application.Common.Mappings;
using Restaurant.Domain;

namespace Restaurant.Application.ViewModels
{
    public class CartDetails : IMapWith<Cart>
    {
        public ICollection<CartItemLookup>? Dishes { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Cart, CartDetails>()
                .ForMember(to => to.Dishes,
                    opt => opt.MapFrom(from => from.Items));
        }
    }
}
