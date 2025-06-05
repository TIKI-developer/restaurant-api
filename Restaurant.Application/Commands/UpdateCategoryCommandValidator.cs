using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Commands
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator(CategoryRules categoryRules)
        {
            categoryRules.Name(RuleFor(cat => cat.Name));
        }
    }
}
