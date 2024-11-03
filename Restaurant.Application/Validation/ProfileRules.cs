using FluentValidation;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Validation
{
    public class ProfileRules(IAddressValidator addressValidator) : ValidationRules
    {
        private readonly IAddressValidator _addressValidator = addressValidator;

        public IRuleBuilderOptions<T, string?> Address<T>(IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                   .Must(_addressValidator.IsValid)
                   .WithMessage("Неверный формат адреса");
        }
        public IRuleBuilderOptions<T, string?> Name<T>(IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                   .Matches(@"^[a-zA-Zа-яА-ЯёЁ]+$");
        }
    }
}
