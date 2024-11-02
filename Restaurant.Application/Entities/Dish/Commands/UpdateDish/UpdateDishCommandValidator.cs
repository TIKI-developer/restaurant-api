using FluentValidation;

namespace Restaurant.Application.Entities.Dish.Commands.UpdateDish
{
    public class UpdateDishCommandValidator : AbstractValidator<UpdateDishCommand>
    {
        public UpdateDishCommandValidator()
        {
            RuleFor(command =>
                command.Name).NotEmpty().MaximumLength(100);
            RuleFor(command =>
                command.Description).MaximumLength(600);
            RuleFor(command =>
                command.Price).GreaterThan(0);
        }
    }
}
