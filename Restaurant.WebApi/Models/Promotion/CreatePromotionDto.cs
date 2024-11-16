using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Application.Entities.Promotion.Command.CreatePromotion;

namespace Restaurant.WebApi.Models.Promotion
{
    public class CreatePromotionDto : IMapWith<CreatePromotionCommand>
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePromotionDto, CreatePromotionCommand>()
                .ForMember(c => c.Title,
                    opt => opt.MapFrom(dto => dto.Title))

                .ForMember(c => c.Description,
                    opt => opt.MapFrom(dto => dto.Description))

                .ForMember(c => c.Image,
                    opt => opt.MapFrom(dto => dto.Image));
        }
    }
}
