using Restaurant.Domain;

namespace Restaurant.WebApi.Models
{
    public class CreateOrderDto
    {
        public required ICollection<Dish> Dishes {  get; set; } 
    }
}
