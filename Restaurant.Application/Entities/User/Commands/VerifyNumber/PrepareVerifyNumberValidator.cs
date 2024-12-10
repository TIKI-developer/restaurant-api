using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Entities.User.Commands.VerifyNumber
{
    public class PrepareVerifyNumberValidator : AbstractValidator<PrepareVerifyNumberCommand>
    {
        public PrepareVerifyNumberValidator(
            AuthRules authRules)
        {
            authRules.Number(RuleFor(c => c.Number));
        }
    }
}
