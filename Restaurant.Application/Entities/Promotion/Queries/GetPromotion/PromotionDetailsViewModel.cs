using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Promotion;

namespace Restaurant.Application.Entities.Promotion.Queries.GetPromotion
{
    public class PromotionDetailsViewModel : IMapWith<PromotionModel>
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime? CreationDateTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PromotionModel, PromotionDetailsViewModel>();
        }
    }
}
