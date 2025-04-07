using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entities;

namespace Restaurant.WebApi.Models
{
    public class UpdateOrderStatusDto : IMapWith<UpdateOrderStatusCommand>
    {
        public string? NewStatus { get; set; }
        public float? DeliveryCost { get; set; }
        public DateTime? ReceiptAt { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<UpdateOrderStatusDto, UpdateOrderStatusCommand>()
                .ForMember(to => to.NewStatus,
                opt => opt.MapFrom(from => Enum.Parse(typeof(OrderStatus), from.NewStatus)));
        }
    }
}
