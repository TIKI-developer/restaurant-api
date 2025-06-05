using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;


namespace Restaurant.WebApi.Models
{
    public class CreateDishDto : IMapWith<CreateDishCommand>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required float Price { get; set; }
        public required float Weight { get; set; }
        public required string Image { get; set; }
        public required CreateContentDto Content { get; set; }
        public ICollection<Guid>? Categories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDishDto, CreateDishCommand>();
        }
    }
}
