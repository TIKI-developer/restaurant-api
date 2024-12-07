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
        public required ICollection<OrderItemViewModel> Dishes { get; set; }
        public required string Code { get; set; }
        public required int PersonQuantity { get; set; }
        public required bool AddForks { get; set; }
        public required bool AddChopsticks { get; set; }
        public required float Cost { get; set; }
        public required string UserName { get; set; }
        public required string UserNumber { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderModel, OrderViewModel>()

                .ForMember(vm => vm.Dishes,
                    opt => opt.MapFrom(o => o.Items))

                .ForMember(vm => vm.UserName,
                    opt => opt.MapFrom(o => o.User.Profile.Name))

                .ForMember(vm => vm.UserNumber,
                    opt => opt.MapFrom(o => o.User.Number));
        }

        public class OrderItemViewModel : IMapWith<OrderItem>
        {
            public required string DishName { get; set; }
            public required int Count { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<OrderItem, OrderItemViewModel>()
                    .ForMember(to => to.DishName,
                        opt => opt.MapFrom(from => from.Dish.Name));
            }
        }
    }
}


