using AutoMapper;
using Restaurant.Application.Commands;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.WebApi.Models
{
    public class CreateBranchDto : IMapWith<CreateBranchCommand>
    {
        public required string Name { get; set; }
        public required bool IsActive { get; set; }
        public required Address Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required ulong AverageCookingTime { get; set; }
        public required ScheduleDto Schedule { get; set; }
        public required Content Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBranchDto, CreateBranchCommand>()
                .ForMember(to => to.Schedule, opt => opt.MapFrom(from => ScheduleDto.MapToSchedule(from.Schedule)));
        }
    }
}
