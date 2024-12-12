using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Order.Commands.Create;
using Restaurant.Domain;

namespace Restaurant.WebApi.Models.Order
{
    public class CreateOrderDto : IMapWith<CreateCommand>
    {
        public Address? Address { get; set; }
        public required int PersonQuantity { get; set; }
        public required bool AddForks { get; set; }
        public required bool AddChopsticks { get; set; }
        public required string PaymentMethod { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateCommand>()
                .ForMember(to => to.PaymentMethod,
                opt => opt.MapFrom(from => Enum.Parse(typeof(PaymentMethod), from.PaymentMethod)));
        }
    }
}
