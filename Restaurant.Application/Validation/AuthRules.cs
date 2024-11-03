using FluentValidation;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Validation
{
    public class AuthRules(IPhoneNumberValidator phoneNumberValidator) : ValidationRules
    {
        private readonly IPhoneNumberValidator _phoneNumberValidator = phoneNumberValidator;
        private readonly string _passwordExpression = "^(?=.*[a-z])(?=.*\\d)[A-Za-z\\d]{8,50}$";

        public IRuleBuilderOptions<T, string?> Number<T>(IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                   .Must(_phoneNumberValidator.IsValidPhoneNumber)
                   .WithMessage("Неверный формат номера");
        }
        public IRuleBuilderOptions<T, string?> Password<T>(IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                   .MinimumLength(8)
                   .WithMessage("Пароль должен иметь больше 8 символов!")
                   .MaximumLength(50)
                   .WithMessage("Пароль должен иметь меньше 50 символов!")
                   .Matches(_passwordExpression)
                   .WithMessage("Пароль должен иметь хотя бы одну букву и одну цифру");
        }
    }
}
