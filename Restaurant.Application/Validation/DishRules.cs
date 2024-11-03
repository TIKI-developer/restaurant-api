using FluentValidation;

namespace Restaurant.Application.Validation
{
    public class DishRules : ValidationRules
    {
        public IRuleBuilderOptions<T, string?> Name<T>(IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                   .MaximumLength(50)
                   .WithMessage("Максимальный размер 50 символов.");
        }
        public IRuleBuilderOptions<T, string?> Description<T>(IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                   .MaximumLength(600)
                   .WithMessage("Максимальный размер 600 символов.");
        }
        public IRuleBuilderOptions<T, float?> Price<T>(IRuleBuilder<T, float?> ruleBuilder)
        {
            return ruleBuilder
                   .GreaterThan(0);
        }
    }
}
