using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Entities.Dish.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator(DishRules rules)
        {
            rules.Name(RuleFor(x => x.Name)).NotEmpty();
            rules.Description(RuleFor(x => x.Description)).NotEmpty();
        }
    }
}
