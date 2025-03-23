using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Entities.Dish.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator(DishRules rules)
        {
            rules.Name(RuleFor(x => x.Name)).NotEmpty();
            rules.Description(RuleFor(x => x.Description)).NotEmpty();
        }
    }
}
