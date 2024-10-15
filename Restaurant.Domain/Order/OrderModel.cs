using Restaurant.Domain.Dish;
using Restaurant.Domain.User;

namespace Restaurant.Domain.Order
{
    public class OrderModel
    {
        public required Guid Id { get; set; }
        public required ICollection<DishModel> Dishes { get; set; }
        public required DateTime CreationDateTime { get; set; }
        public required ClientModel Client { get; set; }
    }
}
