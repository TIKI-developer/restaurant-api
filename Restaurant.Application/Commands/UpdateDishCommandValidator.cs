using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Commands
{
    public class UpdateDishCommandValidator : AbstractValidator<UpdateDishCommand>
    {
        public UpdateDishCommandValidator(DishRules rules)
        {
            rules.Name(RuleFor(x => x.Name)).NotEmpty();
            rules.Description(RuleFor(x => x.Description)).NotEmpty();
        }
    }
}
