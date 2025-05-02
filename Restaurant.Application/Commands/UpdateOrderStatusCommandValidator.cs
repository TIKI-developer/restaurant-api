using FluentValidation;

namespace Restaurant.Application.Commands
{
    public class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
    {
        public UpdateOrderStatusCommandValidator()
        {
            RuleFor(command =>
                command.NewStatus).IsInEnum();
        }
    }
}
