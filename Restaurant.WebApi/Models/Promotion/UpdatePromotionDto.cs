using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Promotion.Command.UpdatePromotion;

namespace Restaurant.WebApi.Models.Promotion
{
    public class UpdatePromotionDto : IMapWith<UpdatePromotionCommand>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePromotionDto, UpdatePromotionCommand>();
        }
    }
}
