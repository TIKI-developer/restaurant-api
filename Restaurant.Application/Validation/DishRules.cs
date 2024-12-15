using FluentValidation;

namespace Restaurant.Application.Validation
{
    public class DishRules : ValidationRules
    {
        public IRuleBuilderOptions<T, string?> Name<T>(IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                   .MaximumLength(50)
                   .WithMessage("Максимум 50 символов");
        }
        public IRuleBuilderOptions<T, string?> Description<T>(IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                   .MaximumLength(600)
                   .WithMessage("Максимальный размер 150 символов");
        }
        public IRuleBuilderOptions<T, float?> Price<T>(IRuleBuilder<T, float?> ruleBuilder)
        {
            return ruleBuilder
                   .GreaterThan(0)
                   .WithMessage("Установите цену");
        }
        public IRuleBuilderOptions<T, float?> Weight<T>(IRuleBuilder<T, float?> ruleBuilder)
        {
            return ruleBuilder
                   .GreaterThan(0)
                   .WithMessage("Масса должна быть больше 0")
                   .LessThan(10000)
                   .WithMessage("Масса должна быть меньше 10000");
        }
    }
}
