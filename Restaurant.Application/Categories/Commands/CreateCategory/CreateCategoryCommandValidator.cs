using FluentValidation;

namespace Restaurant.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator() 
        {
            RuleFor(createDishCommand =>
                createDishCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createDishCommand =>
                createDishCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}
