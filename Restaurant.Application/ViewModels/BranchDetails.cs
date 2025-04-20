using AutoMapper;
using Restaurant.Application.Common.Mappings;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.ViewModels
{
    public class BranchDetails : IMapWith<Branch>
    {
        public required Guid Id { get; set; }
        public required Timestamps Timestamps { get; set; }
        public required string Name { get; set; }
        public required bool IsActive { get; set; }
        public required Address Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required Schedule Schedule { get; set; }
        public required ulong AverageCookingTime { get; set; }
        public required Content Content { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Branch, BranchDetails>();
        }
    }
}
