using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Promotion;

namespace Restaurant.Application.Entities.Promotion.Queries.GetPromotionList
{
    public class PromotionLookupDto : IMapWith<PromotionModel>
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Image { get; set; }
        public DateTime? CreationDateTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PromotionModel, PromotionLookupDto>();
        }
    }
}
