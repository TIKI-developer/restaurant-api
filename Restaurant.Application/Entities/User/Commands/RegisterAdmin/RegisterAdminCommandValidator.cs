using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Entities.User.Commands.RegisterAdmin
{
    public class RegisterAdminCommandValidator : AbstractValidator<RegisterAdminCommand>
    {
        public RegisterAdminCommandValidator(
            AuthRules authRules)
        {
            authRules.Number(RuleFor(c => c.Number));
            authRules.Password(RuleFor(c => c.Password));
        }
    }
}
