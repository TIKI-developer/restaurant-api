using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Dish;
using Restaurant.Domain.Order;
using Restaurant.Domain.User.Client;

namespace Restaurant.Application.Entities.Order.Queries.GetOrder
{
    public class OrderViewModel : IMapWith<OrderModel>
    {
        public required OrderStatus Status { get; set; }
        public required DateTime CreationDateTime { get; set; }
        public required ICollection<Guid> Dishes { get; set; }
        public required Guid ClientId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderModel, OrderViewModel>()
                .ForMember(vm => vm.Status,
                    opt => opt.MapFrom(o => o.Status))

                .ForMember(vm => vm.CreationDateTime,
                    opt => opt.MapFrom(o => o.CreationDateTime))

                .ForMember(vm => vm.Dishes,
                    opt => opt.MapFrom(o => o.Dishes.Select(d => d.Id)))

                .ForMember(vm => vm.ClientId,
                    opt => opt.MapFrom(o => o.Client.Id));
        }
    }
}
