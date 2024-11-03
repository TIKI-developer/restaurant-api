using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Entities.User.Commands.RegisterClient
{
    public class RegisterClientCommandValidator : AbstractValidator<RegisterClientCommand> 
    {
        public RegisterClientCommandValidator(
            AuthRules authRules,
            ProfileRules profileRules)
        {
            profileRules.Name(RuleFor(x => x.Name));
            authRules.Number(RuleFor(c => c.Number));
            authRules.Password(RuleFor(c => c.Password));
        }
    }
}
