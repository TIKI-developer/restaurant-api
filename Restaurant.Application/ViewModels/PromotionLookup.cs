using Restaurant.Application.Common.Mappings;
using Restaurant.Domain;

namespace Restaurant.Application.ViewModels
{
    public class PromotionLookup : IMapWith<Promotion>
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Image { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Promotion, PromotionLookup>();
        }
    }
}
