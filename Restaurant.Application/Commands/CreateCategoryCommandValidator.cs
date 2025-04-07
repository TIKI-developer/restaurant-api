using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Commands
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator(CategoryRules categoryRules)
        {
            categoryRules.Name(RuleFor(cat => cat.Name));
        }
    }
}
