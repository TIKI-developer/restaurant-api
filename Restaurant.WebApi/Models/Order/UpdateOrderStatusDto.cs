using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Order.Commands.UpdateStatus;
using Restaurant.Domain;

namespace Restaurant.WebApi.Models.Order
{
    public class UpdateOrderStatusDto : IMapWith<UpdateStatusCommand>
    {
        public required string NewStatus { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<UpdateOrderStatusDto, UpdateStatusCommand>()
                .ForMember(to => to.NewStatus, 
                opt => opt.MapFrom(from => Enum.Parse(typeof(OrderStatus), from.NewStatus)));
        }
    }
}
