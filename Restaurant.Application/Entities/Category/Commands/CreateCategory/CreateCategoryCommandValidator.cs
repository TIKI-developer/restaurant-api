using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Entities.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator(CategoryRules categoryRules)
        {
            categoryRules.Name(RuleFor(cat => cat.Name));
        }
    }
}
