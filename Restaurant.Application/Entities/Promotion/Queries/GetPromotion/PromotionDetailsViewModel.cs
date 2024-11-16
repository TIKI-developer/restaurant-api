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
            profile.CreateMap<PromotionModel, PromotionDetailsViewModel>()
                .ForMember(vm => vm.Title,
                    opt => opt.MapFrom(p => p.Title))

                .ForMember(vm => vm.Description,
                    opt => opt.MapFrom(p => p.Description))

                .ForMember(vm => vm.Image,
                    opt => opt.MapFrom(p => p.Image))

                .ForMember(vm => vm.CreationDateTime,
                    opt => opt.MapFrom(p => p.CreationDateTime));
        }
    }
}
