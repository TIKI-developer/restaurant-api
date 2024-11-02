using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Order.Commands.UpdateOrderStatus;
using Restaurant.Domain.Order;

namespace Restaurant.WebApi.Models.Order
{
    public class UpdateOrderStatusDto : IMapWith<UpdateOrderStatusCommand>
    {
        public OrderStatus NewStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderStatusDto, UpdateOrderStatusCommand>()

                .ForMember(d => d.NewStatus,
                    opt => opt.MapFrom(dto => dto.NewStatus));
        }
    }
}
