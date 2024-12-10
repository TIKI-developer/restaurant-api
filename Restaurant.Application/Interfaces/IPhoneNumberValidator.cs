namespace Restaurant.Application.Interfaces
{
    public interface IPhoneNumberValidator
    {
        bool IsValidPhoneNumber(string? phoneNumber);
        string NormalizePhoneNumber(string? phoneNumber);
    }
}
