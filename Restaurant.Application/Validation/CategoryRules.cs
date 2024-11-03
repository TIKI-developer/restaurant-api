using FluentValidation;

namespace Restaurant.Application.Validation
{
    public class CategoryRules : ValidationRules
    {
        public IRuleBuilderOptions<T, string?> Name<T>(IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder.MaximumLength(4).WithMessage("Максимум 50 символов"); ;
        }
    }
}

