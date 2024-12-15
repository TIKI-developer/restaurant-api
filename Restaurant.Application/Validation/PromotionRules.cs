using FluentValidation;

namespace Restaurant.Application.Validation
{
    public class PromotionRules : ValidationRules
    {
        public IRuleBuilderOptions<T, string?> Title<T>(IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                .MaximumLength(50)
                .WithMessage("Максимум 50 символов");
        }
    }
}

