using FluentValidation;

namespace Restaurant.Application.Entities.Dish.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator() { }
    }
}
