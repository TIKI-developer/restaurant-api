using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Entities.Category.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator(CategoryRules categoryRules)
        {
            categoryRules.Name(RuleFor(cat => cat.Name));
        }
    }
}
