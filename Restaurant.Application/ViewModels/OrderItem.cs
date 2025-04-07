using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.ViewModels
{
    public class OrderItem : IMapWith<Order>
    {
        public required Guid Id { get; set; }
        public required string Code { get; set; }
        public required string UserName { get; set; }
        public required string UserPhoneNumber { get; set; }
        public required string Status { get; set; }
        public required string ReceiptMethod { get; set; }
        public required float Cost { get; set; }
        public required DateTime ReceiptAt { get; set; }
        public required Timestamps Timestamps { get; set; }
        public required Guid UserId { get; set; }
        public required ICollection<OrderDetails.OrderItemLookup> Dishes { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Order, OrderItem>()

                .ForMember(orderDto => orderDto.Dishes,
                    opt => opt.MapFrom(order => order.Items))

                .ForMember(to => to.Status,
                    opt => opt.MapFrom(from => from.Status.ToString()))

                .ForMember(to => to.ReceiptMethod,
                    opt => opt.MapFrom(from => from.ReceiptMethod.ToString()))

                .ForMember(orderDto => orderDto.UserName,
                    opt => opt.MapFrom(order => order.User.Profile.Name))

                .ForMember(orderDto => orderDto.UserPhoneNumber,
                    opt => opt.MapFrom(order => order.User.PhoneNumber))

                .ForMember(orderDto => orderDto.UserId,
                    opt => opt.MapFrom(order => order.User.Id));
        }
    }
}
