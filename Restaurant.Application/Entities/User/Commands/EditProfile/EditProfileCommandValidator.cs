using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Entities.User.Commands.EditProfile
{
    public class EditProfileCommandValidator : AbstractValidator<EditProfileCommand>
    {
        public EditProfileCommandValidator(
            ProfileRules profileRules,
            AuthRules authRules)
        {
            profileRules.Address(RuleFor(c => c.Address)).When(c => c.Address != null);
            profileRules.Name(RuleFor(c => c.Name)).When(c => c.Name != null);
            authRules.Number(RuleFor(c => c.Number)).When(c => c.Number != null);
        }
    }
}
