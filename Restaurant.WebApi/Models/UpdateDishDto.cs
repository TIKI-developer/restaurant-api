using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Dishes.Commands.UpdateDish;
using Restaurant.Domain;
using AutoMapper;
using Restaurant.Application.Dishes.Commands.CreateDish;

namespace Restaurant.WebApi.Models
{
    public class UpdateDishDto : IMapWith<UpdateDishCommand>
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public byte[]? Image { get; set; }
        public ICollection<Category>? Categories { get; set; }

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
