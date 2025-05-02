using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Commands
{
    public class UpdatePromotionCommandValidator : AbstractValidator<UpdatePromotionCommand>
    {
        public UpdatePromotionCommandValidator(PromotionRules rules)
        {
            rules.Title(RuleFor(x => x.Title)).NotEmpty();
        }
    }
}
