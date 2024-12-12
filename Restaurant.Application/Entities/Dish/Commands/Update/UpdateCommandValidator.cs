using FluentValidation;

namespace Restaurant.Application.Entities.Dish.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator() { }
    }
}
