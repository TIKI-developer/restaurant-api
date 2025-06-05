using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;

namespace Restaurant.WebApi.Models
{
    public class CreatePromotionDto : IMapWith<CreatePromotionCommand>
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required bool IsAdvanced { get; set; }
        public required CreateContentDto Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePromotionDto, CreatePromotionCommand>();
        }
    }
}
