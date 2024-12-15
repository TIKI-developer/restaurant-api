using FluentValidation;

namespace Restaurant.Application.Validation
{
    public class CategoryRules : ValidationRules
    {
        public IRuleBuilderOptions<T, string?> Name<T>(IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder.MaximumLength(15).WithMessage("Максимум 15 символов"); ;
        }
    }
}

