using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.ViewModels
{
    public class OrderDetails : IMapWith<Order>
    {
        public required string Status { get; set; }
        public required Content Content { get; set; }
        public required Timestamps Timestamps { get; set; }
        public Address? Address { get; set; }
        public required string Code { get; set; }
        public required int PersonQuantity { get; set; }
        public required string ReceiptMethod { get; set; }
        public required DateTime ReceiptAt { get; set; }
        public float? DeliveryCost { get; set; }
        public required bool AddForks { get; set; }
        public required bool AddChopsticks { get; set; }
        public required string PaymentMethod { get; set; }
        public required float Cost { get; set; }
        public string? Comment { get; set; }
        public required string UserName { get; set; }
        public required string UserNumber { get; set; }
        public required ICollection<OrderItemLookup> Dishes { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Order, OrderDetails>()

                .ForMember(to => to.Dishes,
                    opt => opt.MapFrom(from => from.Items))

                .ForMember(to => to.Status,
                    opt => opt.MapFrom(from => from.Status.ToString()))

                .ForMember(to => to.UserName,
                    opt => opt.MapFrom<string>(from => from.User.Profile.Name))

                .ForMember(to => to.PaymentMethod,
                    opt => opt.MapFrom(from => from.PaymentMethod.ToString()))

                .ForMember(to => to.ReceiptMethod,
                    opt => opt.MapFrom(from => from.ReceiptMethod.ToString()))

                .ForMember(to => to.Address,
                    opt => opt.MapFrom(from => from.Address))

                .ForMember(to => to.UserNumber,
                    opt => opt.MapFrom(from => from.User.PhoneNumber));
        }

        public class OrderItemLookup : IMapWith<Domain.Entities.OrderItem>
        {
            public required string DishName { get; set; }
            public required int Count { get; set; }

            public void Mapping(AutoMapper.Profile profile)
            {
                profile.CreateMap<Domain.Entities.OrderItem, OrderItemLookup>()
                    .ForMember(to => to.DishName,
                        opt => opt.MapFrom(from => from.Dish.Name));
            }
        }
    }
}


