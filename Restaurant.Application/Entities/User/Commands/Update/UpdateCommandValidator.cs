using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Entities.User.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator
            (ProfileRules profileRules,
            AuthRules authRules)
        {
            //profileRules
            //    .Address(RuleFor(c =>
            //    $"{c.Address!.City}, {c.Address!.Street}, {c.Address!.BuildingNumber}, кв. {c.Address!.ApartmentNumber}"))
            //    .When(c => c.Address != null);
            profileRules.Name(RuleFor(c => c.Name)).When(c => c.Name != null);
            authRules.Number(RuleFor(c => c.PhoneNumber)).When(c => c.PhoneNumber != null);
        }
    }
}
