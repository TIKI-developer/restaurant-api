using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Entities.User.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator
            (AuthRules authRules,
            ProfileRules profileRules)
        {
            profileRules.Name(RuleFor(x => x.Name));
            //authRules.Number(RuleFor(c => c.Number));
        }
    }
}
