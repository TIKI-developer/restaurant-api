using Restaurant.Application.Interfaces;
using System.Text.RegularExpressions;

namespace Restaurant.Validation
{
    public class AddressValidator : IAddressValidator
    {
        private readonly string _pattern = @"^(?<city>[A-Za-zА-Яа-яЁё0-9\s\-]+),\s*" +
                                           @"(?<street>[A-Za-zА-Яа-яЁё0-9\s\-]+),\s*" +
                                           @"(?<building>\d+([A-Za-zА-Яа-я]|-\d+)?)" +
                                           @"(,\s*кв.\s*(?<apartment>\d+([A-Za-zА-Яа-я]|-\d+)?))?" +
                                           @"(,\s*под.\s*(?<entrance>\d+([A-Za-zА-Яа-я]|-\d+)?))?$";

        public bool IsValid(string? address)
        {
            if (string.IsNullOrEmpty(address)) return false;

            return Regex.IsMatch(address, _pattern);
        }
    }
}
