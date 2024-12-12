using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Entities.Category.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator(CategoryRules categoryRules)
        {
            categoryRules.Name(RuleFor(cat => cat.Name));
        }
    }
}
