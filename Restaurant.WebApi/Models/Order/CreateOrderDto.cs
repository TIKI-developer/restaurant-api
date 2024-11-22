using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Order.Commands.CreateOrder;

namespace Restaurant.WebApi.Models.Order
{
    public class CreateOrderDto : IMapWith<CreateOrderCommand>
    {
        public required string Address { get; set; }
        public required int PersonQuantity { get; set; }
        public bool AddForks { get; set; }
        public bool AddChopsticks { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
                .ForMember(to => to.Address,
                    opt => opt.MapFrom(from => from.Address))
                .ForMember(to => to.PersonQuantity,
                    opt => opt.MapFrom(from => from.PersonQuantity))
                .ForMember(to => to.AddForks,
                    opt => opt.MapFrom(from => from.AddForks))
                .ForMember(to => to.AddChopsticks,
                    opt => opt.MapFrom(from => from.AddChopsticks));
        }
    }
}
