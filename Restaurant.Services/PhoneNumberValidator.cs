using PhoneNumbers;
using Restaurant.Application.Interfaces;

namespace Restaurant.Validation
{
    public class PhoneNumberValidator : IPhoneNumberValidator
    {
        public bool IsValidPhoneNumber(string? phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) return false;

            var phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var parsedNumber = phoneUtil.Parse(phoneNumber, "RU");
                return phoneUtil.IsValidNumber(parsedNumber);
            }
            catch (NumberParseException)
            {
                return false;
            }
        }
        public string NormalizePhoneNumber(string? phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) return "";
            if (phoneNumber.StartsWith("89"))
            {
                return string.Concat("+7", phoneNumber.AsSpan(1));
            }
            return phoneNumber;
        }
    }
}
