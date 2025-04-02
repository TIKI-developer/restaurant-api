using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Order.Commands.Create;
using Restaurant.Domain;
using Restaurant.WebApi.Models.Cart;

namespace Restaurant.WebApi.Models.Order
{
    public class CreateOrderDto : IMapWith<CreateCommand>
    {
        public Guid? AddressId { get; set; }
        public required int PersonQuantity { get; set; }
        public required bool AddForks { get; set; }
        public required bool AddChopsticks { get; set; }
        public required string PaymentMethod { get; set; }
        public required DateTime ReceiptAt { get; set; }
        public required string ReceiptMethod { get; set; }
        public string? Comment { get; set; }
        public CartBodyDto? Cart { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<CreateOrderDto, CreateCommand>()
                .ForMember(to => to.PaymentMethod,
                opt => opt.MapFrom(from => Enum.Parse(typeof(PaymentMethod), from.PaymentMethod)))
                .ForMember(to => to.ReceiptMethod,
                opt => opt.MapFrom(from => Enum.Parse(typeof(ReceiptMethod), from.ReceiptMethod)));
        }
    }
}
