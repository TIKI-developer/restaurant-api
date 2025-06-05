using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Commands
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator(DishRules rules)
        {
            rules.Name(RuleFor(x => x.Name)).NotEmpty();
            rules.Description(RuleFor(x => x.Description)).NotEmpty();
        }
    }
}
