using Restaurant.Application.Interfaces;
using System.Text.RegularExpressions;

namespace Restaurant.Validation
{
    public class AddressValidator : IAddressValidator
    {
        private readonly string _pattern = @"^(?<city>[A-Za-zА-Яа-яЁё\s]+),\s*" +
                                           @"(?<street>[A-Za-zА-Яа-яЁё\s]+),\s*" +
                                           @"(?<building>\d+)" +
                                           @"(,\s*кв.\s*(?<apartment>\d+))?" +
                                           @"(,\s*под.\s*(?<entrance>\d+))?$";
        public bool IsValid(string? address)
        {
            if (string.IsNullOrEmpty(address)) return false;

            return Regex.IsMatch(address, _pattern);
        }
    }
}
