using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Order.Queries.GetOrder;
using Restaurant.Domain.Order;

namespace Restaurant.Application.Entities.Order.Queries.GetOrderList
{
    public class OrderLookupDto : IMapWith<OrderModel>
    {
        public required Guid Id { get; set; }
        public required ICollection<OrderViewModel.OrderItemViewModel> Dishes { get; set; }
        public required OrderStatus Status { get; set; }
        public required DateTime CreationDateTime { get; set; }
        public required Guid UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderModel, OrderLookupDto>()

                .ForMember(orderDto => orderDto.Dishes,
                    opt => opt.MapFrom(order => order.Items))

                .ForMember(orderDto => orderDto.UserId,
                    opt => opt.MapFrom(order => order.User.Id));
        }
    }
}
