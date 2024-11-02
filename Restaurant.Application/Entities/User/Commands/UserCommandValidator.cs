using FluentValidation;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.User.Commands
{
    public class UserCommandValidator<T> : AbstractValidator<T> where T : IHasNumber
    {
        public UserCommandValidator(IPhoneNumberValidator phoneNumberValidator)
        {
            RuleFor(command =>
                command.Number)
                        .Must(phoneNumberValidator.IsValidPhoneNumber)
                        .WithMessage("Неверный формат номера");
        }
    }
    public interface IHasNumber
    {
        public string Number { get; set; }
    }
}
