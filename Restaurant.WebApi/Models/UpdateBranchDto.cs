using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.WebApi.Models
{
    public class UpdateBranchDto : IMapWith<UpdateBranchCommand>
    {
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public Address? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public ScheduleDto? Schedule { get; set; }
        public ulong? AverageCookingTime { get; set; }
        public Content? Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBranchDto, UpdateBranchCommand>()
                .ForMember(to => to.Schedule, opt => opt.MapFrom(from => ScheduleDto.MapToSchedule(from.Schedule)));
        }
    }
}
