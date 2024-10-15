using FluentValidation;

namespace Restaurant.Application.Entities.Dish.Commands.CreateDish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(createDishCommand =>
                createDishCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(createDishCommand =>
                createDishCommand.Description).MaximumLength(600);
        }
    }
}
