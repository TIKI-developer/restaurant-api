using FluentValidation;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.User.Commands.EditProfile
{
    public class EditProfileCommandValidator : UserCommandValidator<EditProfileCommand>
    {
        public EditProfileCommandValidator(
            IPhoneNumberValidator phoneNumberValidator, 
            IAddressValidator addressValidator) : base(phoneNumberValidator)
        {
            RuleFor(command => 
                command.Name)
                    .Matches(@"^[a-zA-Zа-яА-ЯёЁ]+$");
            RuleFor(command =>
                command.Address)
                    .Must(addressValidator.IsValid)
                    .WithMessage("Неверный формат адреса");
        }
    }
}
