using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Order;
using Restaurant.Domain.Dish;
using Restaurant.Domain.User;

namespace Restaurant.Application.Entities.Order.Queries.GetOrderList
{
    public class OrderLookupDto : IMapWith<OrderModel>
    {
        public required Guid Id { get; set; }
        public required ICollection<Guid> Dishes { get; set; }
        public required OrderStatus Status { get; set; }
        public required DateTime CreationDateTime { get; set; }
        public required Guid Client { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderModel, OrderLookupDto>()

                .ForMember(orderDto => orderDto.Id,
                    opt => opt.MapFrom(order => order.Id))

                .ForMember(orderDto => orderDto.Dishes,
                    opt => opt.MapFrom(order => order.Items.Select(d => d.DishId)))

                .ForMember(orderDto => orderDto.Status,
                    opt => opt.MapFrom(order => order.Status))

                .ForMember(orderDto => orderDto.CreationDateTime,
                    opt => opt.MapFrom(order => order.CreationDateTime))

                .ForMember(orderDto => orderDto.Client,
                    opt => opt.MapFrom(order => order.Client.Id));
        }
    }
}
