using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Promotion.Command.Create;
using Restaurant.WebApi.Models.Content;

namespace Restaurant.WebApi.Models.Promotion
{
    public class CreatePromotionDto : IMapWith<CreateCommand>
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required bool IsAdvanced { get; set; }
        public required CreateContentDto Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePromotionDto, CreateCommand>();
        }
    }
}
