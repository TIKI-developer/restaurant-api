using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Dish.Commands.UpdateDish;

namespace Restaurant.WebApi.Models.Dish
{
    public class UpdateDishDto : IMapWith<UpdateDishCommand>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public string? Image { get; set; }
        public ICollection<Guid>? Categories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDishDto, UpdateDishCommand>();
        }
    }
}
