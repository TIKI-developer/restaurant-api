using Restaurant.Application.Common.Mappings;
using AutoMapper;
using Restaurant.Application.Entities.Dish.Commands.UpdateDish;
using Restaurant.Domain.Category;

namespace Restaurant.WebApi.Models.Dish
{
    public class UpdateDishDto : IMapWith<UpdateDishCommand>
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public byte[]? Image { get; set; }
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

                .ForMember(dishVm => dishVm.Image,
                    opt => opt.MapFrom(dish => dish.Image))

                .ForMember(dishVm => dishVm.Categories,
                    opt => opt.MapFrom(dish => dish.Categories));
        }
    }
}
