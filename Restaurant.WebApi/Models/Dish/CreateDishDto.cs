using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Dish.Commands.Create;


namespace Restaurant.WebApi.Models.Dish
{
    public class CreateDishDto : IMapWith<CreateCommand>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required float Price { get; set; }
        public required string Image { get; set; }
        public ICollection<Guid>? Categories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDishDto, CreateCommand>();
        }
    }
}
