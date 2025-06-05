using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.ViewModels
{
    public class PromotionItem : IMapWith<Promotion>
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Image { get; set; }
        public required bool IsAdvanced { get; set; }
        public required Timestamps Timestamps { get; set; }
        public required Content Content { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Promotion, PromotionItem>();
        }
    }
}
