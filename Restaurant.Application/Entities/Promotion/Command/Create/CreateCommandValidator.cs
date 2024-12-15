using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Entities.Promotion.Command.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator(PromotionRules rules) 
        {
            rules.Title(RuleFor(x => x.Title)).NotEmpty();
        }
    }
}
