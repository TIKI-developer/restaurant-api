using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Commands
{
    public class PrepareVerificationPhoneNumberValidator : AbstractValidator<PrepareVerificationPhoneNumberCommand>
    {
        public PrepareVerificationPhoneNumberValidator
            (AuthRules authRules)
        {
            authRules.Number(RuleFor(c => c.Number));
        }
    }
}
