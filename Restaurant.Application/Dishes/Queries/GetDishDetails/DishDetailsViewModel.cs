using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain;

namespace Restaurant.Application.Dishes.Queries.GetDishDetails
{
    public class DishDetailsViewModel : IMapWith<Dish>
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required float Price { get; set; }
        public byte[]? Image { get; set; }
        public ICollection<Category>? Categories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dish, DishDetailsViewModel>()

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