using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.ViewModels
{
    public partial class OrderDetails
    {
        public class OrderDishItemDto : IMapWith<OrderDishItem>
        {
            public required OrderDish Dish { get; set; }
            public required int Count { get; set; }

            public void Mapping(AutoMapper.Profile profile)
            {
                profile.CreateMap<OrderDishItem, OrderDishItemDto>();
            }
        }
    }
}


