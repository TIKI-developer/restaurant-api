using Restaurant.Application.Interfaces;
using System.Text.RegularExpressions;

namespace Restaurant.Validation
{
    public class AddressValidator : IAddressValidator
    {
        private readonly string _pattern = @"^(?<city>[A-Za-zА-Яа-яЁё0-9\s\-.,]*),?\s*" +
                                           @"(?<street>[A-Za-zА-Яа-яЁё0-9\s\-.,]*),?\s*" +
                                           @"(?<building>[A-Za-zА-Яа-яЁё0-9\s\-.,]*),?\s*" +
                                           @"(?<apartment>[A-Za-zА-Яа-яЁё0-9\s\-.,]*)?,?\s*" +
                                           @"(?<entrance>[A-Za-zА-Яа-яЁё0-9\s\-.,]*)?,?\s*" +
                                           @"(?<floor>[A-Za-zА-Яа-яЁё0-9\s\-.,]*)?$";

        public bool IsValid(string? address)
        {
            if (string.IsNullOrEmpty(address)) return false;

            return Regex.IsMatch(address, _pattern);
        }
    }
}
