using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Commands
{
    public class UpdateUserProfileCommandValidator : AbstractValidator<UpdateUserProfileCommand>
    {
        public UpdateUserProfileCommandValidator
            (ProfileRules profileRules,
            AuthRules authRules)
        {
            //profileRules
            //    .Address(RuleFor(c =>
            //    $"{c.Address!.City}, " +
            //    $"{c.Address!.Street}, " +
            //    $"{c.Address!.BuildingNumber}, " +
            //    $"{c.Address!.ApartmentNumber}, " +
            //    $"{c.Address!.Entrance}, " +
            //    $"{c.Address!.Floor}"))
            //    .When(c => c.Address != null);
            profileRules.Name(RuleFor(c => c.Name)).When(c => c.Name != null);
            authRules.Number(RuleFor(c => c.PhoneNumber)).When(c => c.PhoneNumber != null);
        }
    }
}
