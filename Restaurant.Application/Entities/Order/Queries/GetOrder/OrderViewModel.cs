using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Order;

namespace Restaurant.Application.Entities.Order.Queries.GetOrder
{
    public class OrderViewModel : IMapWith<OrderModel>
    {
        public required OrderStatus Status { get; set; }
        public required DateTime CreationDateTime { get; set; }
        public required string Address { get; set; }
        public required ICollection<OrderItem> Dishes { get; set; }
        public required string ClientName { get; set; }
        public required string ClientNumber { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderModel, OrderViewModel>()
                .ForMember(vm => vm.Status,
                    opt => opt.MapFrom(o => o.Status))

                .ForMember(vm => vm.CreationDateTime,
                    opt => opt.MapFrom(o => o.CreationDateTime))

             .ForMember(vm => vm.Address,
                    opt => opt.MapFrom(o => o.Address))

                .ForMember(vm => vm.Dishes,
                    opt => opt.MapFrom(o => o.Items))

                .ForMember(vm => vm.ClientName,
                    opt => opt.MapFrom(o => o.Client.Profile.Name))

                .ForMember(vm => vm.ClientNumber,
                    opt => opt.MapFrom(o => o.Client.Number));
        }
    }
}
