using FluentValidation;

namespace Restaurant.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator() 
        {
            //RuleFor(createDishCommand =>
            //    createDishCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createDishCommand =>
                createDishCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(createDishCommand =>
                createDishCommand.Description).MinimumLength(600);
        }
    }
}
