using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Promotion.Command.CreatePromotion;

namespace Restaurant.WebApi.Models.Promotion
{
    public class CreatePromotionDto : IMapWith<CreatePromotionCommand>
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePromotionDto, CreatePromotionCommand>();
        }
    }
}
