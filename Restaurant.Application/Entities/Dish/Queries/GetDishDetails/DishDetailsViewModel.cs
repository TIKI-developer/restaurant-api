using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Dish;

namespace Restaurant.Application.Entities.Dish.Queries.GetDishDetails
{
    public class DishDetailsViewModel : IMapWith<DishModel>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required float Price { get; set; }
        public List<string>? Images { get; set; }
        public ICollection<Guid>? Categories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DishModel, DishDetailsViewModel>()

                .ForMember(dishVm => dishVm.Name,
                    opt => opt.MapFrom(dish => dish.Name))

                .ForMember(dishVm => dishVm.Description,
                    opt => opt.MapFrom(dish => dish.Description))

                .ForMember(dishVm => dishVm.Price,
                    opt => opt.MapFrom(dish => dish.Price))

                .ForMember(dishVm => dishVm.Images,
                    opt => opt.MapFrom(dish => dish.Images))

                .ForMember(dishVm => dishVm.Categories,
                    opt => opt.MapFrom(dish => dish.Categories.Select(c => c.Id)));
        }
    }
}