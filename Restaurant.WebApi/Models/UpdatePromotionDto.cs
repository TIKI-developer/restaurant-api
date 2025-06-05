using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;

namespace Restaurant.WebApi.Models
{
    public class UpdatePromotionDto : IMapWith<UpdatePromotionCommand>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public bool? IsAdvanced { get; set; }
        public UpdateContentDto? Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePromotionDto, UpdatePromotionCommand>();
        }
    }
}
