using FluentValidation;

namespace Restaurant.Application.Entities.Order.Commands.UpdateStatus
{
    public class UpdateStatusCommandValidator : AbstractValidator<UpdateStatusCommand>
    {
        public UpdateStatusCommandValidator()
        {
            RuleFor(command =>
                command.NewStatus).IsInEnum();
        }
    }
}
