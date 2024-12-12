using Restaurant.Application.Common.Mappings;
using Restaurant.Domain;

namespace Restaurant.Application.ViewModels
{
    public class PromotionDetails : IMapWith<Promotion>
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required bool IsAdvanced { get; set; }
        public required Content Content { get; set; }
        public required Timestamps Timestamps { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Promotion, PromotionDetails>();
        }
    }
}
