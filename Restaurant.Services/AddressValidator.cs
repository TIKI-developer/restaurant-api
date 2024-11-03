using Restaurant.Application.Interfaces;
using System.Text.RegularExpressions;

namespace Restaurant.Validation
{
    public class AddressValidator : IAddressValidator
    {
        private readonly string _pattern = @"^(?<city>[A-Za-zА-Яа-яЁё\s]+),\s*" +
                                           @"(?<street>[A-Za-zА-Яа-яЁё\s]+),\s*" +
                                           @"(?<building>\d+)" +
                                           @"(,\s*Квартира\s*(?<apartment>\d+))?" +
                                           @"(,\s*Подъезд\s*(?<entrance>\d+))?$";
        public bool IsValid(string address)
        {
            Console.WriteLine(address);
            return Regex.IsMatch(address, _pattern);
        }
    }
}
