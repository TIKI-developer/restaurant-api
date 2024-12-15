using FluentValidation;
using Restaurant.Application.Validation;

namespace Restaurant.Application.Entities.Promotion.Command.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator(PromotionRules rules)
        {
            rules.Title(RuleFor(x => x.Title)).NotEmpty();
        }
    }
}
