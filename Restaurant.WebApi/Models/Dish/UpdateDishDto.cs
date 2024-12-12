using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Dish.Commands.Update;
using Restaurant.WebApi.Models.Content;

namespace Restaurant.WebApi.Models.Dish
{
    public class UpdateDishDto : IMapWith<UpdateCommand>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public string? Image { get; set; }
        public UpdateContentDto? Content { get; set; }
        public ICollection<Guid>? Categories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDishDto, UpdateCommand>();
        }
    }
}
