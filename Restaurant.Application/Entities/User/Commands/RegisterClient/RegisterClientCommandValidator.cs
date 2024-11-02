using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.User.Commands.RegisterClient
{
    public class RegisterClientCommandValidator(IPhoneNumberValidator phoneNumberValidator) 
        : RegisterUserCommandValidator<RegisterClientCommand>(phoneNumberValidator)
    {
    }
}
