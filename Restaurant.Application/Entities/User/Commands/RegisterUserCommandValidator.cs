using FluentValidation;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.User.Commands
{
    public abstract class RegisterUserCommandValidator<T> : UserCommandValidator<T> where T : IRegisterUserCommand
    {
        private readonly string _passwordExpression = "^(?=.*[a-z])(?=.*\\d)[A-Za-z\\d]{8,50}$";

        public RegisterUserCommandValidator(IPhoneNumberValidator phoneNumberValidator) 
            : base(phoneNumberValidator) 
        {
            RuleFor(command =>
                command.Password)
                    .MinimumLength(8)
                    .WithMessage("Пароль должен иметь больше 8 символов!")
                    .MaximumLength(50)
                    .WithMessage("Пароль должен иметь меньше 50 символов!")
                    .Matches(_passwordExpression)
                    .WithMessage("Пароль должен иметь хотя бы одну букву и одну цифру");
        }
    }
    public interface IRegisterUserCommand : IHasNumber, IHasPassword { }
    public interface IHasPassword
    {
        public string Password { get; set; }
    }
}