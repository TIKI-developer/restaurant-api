using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.User.Commands.RegisterAdmin
{
    public class RegisterAdminCommandValidator(IPhoneNumberValidator phoneNumberValidator) 
        : RegisterUserCommandValidator<RegisterAdminCommand>(phoneNumberValidator)
    {
    }
}
