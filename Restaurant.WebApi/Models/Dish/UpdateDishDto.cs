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
        public string[]? Images { get; set; }
        public ICollection<Guid>? Categories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDishDto, UpdateDishCommand>()

                .ForMember(dishVm => dishVm.Name,
                    opt => opt.MapFrom(dish => dish.Name))

                .ForMember(dishVm => dishVm.Description,
                    opt => opt.MapFrom(dish => dish.Description))

                .ForMember(dishVm => dishVm.Price,
                    opt => opt.MapFrom(dish => dish.Price))

                .ForMember(dishVm => dishVm.Images,
                    opt => opt.MapFrom(dish => dish.Images))

                .ForMember(dishVm => dishVm.Categories,
                    opt => opt.MapFrom(dish => dish.Categories));
        }
    }
}
