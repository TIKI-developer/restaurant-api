using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Commands
{
    public class CreatePromotionCommandValidator : AbstractValidator<CreatePromotionCommand>
    {
        public CreatePromotionCommandValidator(PromotionRules rules)
        {
            rules.Title(RuleFor(x => x.Title)).NotEmpty();
        }
    }
}
