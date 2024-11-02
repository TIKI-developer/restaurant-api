using FluentValidation;

namespace Restaurant.Application.Entities.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand> 
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(command =>
                command.Name).NotEmpty().MaximumLength(250);
        }
    }
}
