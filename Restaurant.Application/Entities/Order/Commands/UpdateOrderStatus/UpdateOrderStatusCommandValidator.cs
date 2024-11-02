using FluentValidation;

namespace Restaurant.Application.Entities.Order.Commands.UpdateOrderStatus
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
