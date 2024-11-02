using FluentValidation;

namespace Restaurant.Application.Entities.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(command =>
                command.Name).NotEmpty().MaximumLength(250);
        }
    }
}
