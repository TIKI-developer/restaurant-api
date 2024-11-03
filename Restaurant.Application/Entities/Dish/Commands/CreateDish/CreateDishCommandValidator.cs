using FluentValidation;

namespace Restaurant.Application.Entities.Dish.Commands.CreateDish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
        }
    }
}
