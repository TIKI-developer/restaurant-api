using Microsoft.Extensions.Options;
using Restaurant.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Restaurant.Verification
{
    public class NumberVerifier(IOptions<SmsRuOptions> smsRuOptions) : INumberVerifier
    {
        private readonly SmsRuOptions _smsRuOptions = smsRuOptions.Value;

        public string Verify(string[] postData, string providedHash)
        {
            if (postData == null || postData.Length <= 0)
            {
                return string.Empty;
            }

            string apiId = _smsRuOptions.ApiKey;

            // Создаем массив данных, исключая последний элемент (предоставленный хеш)
            string[] data = new string[postData.Length];
            Array.Copy(postData, data, postData.Length);

            // Формируем строку для хеширования
            string hash = string.Join("", data);
            string calculatedHash;

            foreach (string key in data)
            {
                Console.WriteLine(key);
            }
            Console.WriteLine(apiId);

            // Используем MD5 вместо SHA256
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(apiId + hash));
                calculatedHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }

            Console.WriteLine(providedHash);
            Console.WriteLine(calculatedHash);
            // Сравниваем предоставленный хеш с рассчитанным
            if (providedHash == calculatedHash)
            {
                foreach (var entry in data)
                {
                    var lines = entry.Split('\n');
                    switch (lines[0])
                    {
                        case "sms_status":
                            string smsId = lines[1];
                            string smsStatus = lines[2];
                            string unixTimestamp = lines[3];
                            Console.WriteLine($"Изменение статуса. Сообщение: {smsId}. Новый статус: {smsStatus}. Время: {unixTimestamp}");
                            return smsId;

                        case "callcheck_status":
                            string checkId = lines[1];
                            string checkStatus = lines[2];
                            unixTimestamp = lines[3];

                            if (checkStatus == "401")
                            {
                                Console.WriteLine($"Авторизация пройдена успешно. Идентификатор авторизации: {checkId}");
                                return checkId;
                            }
                            else if (checkStatus == "402")
                            {
                                Console.WriteLine($"Истекло время авторизации. Идентификатор авторизации: {checkId}");
                                return string.Empty;
                            }
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный хэш");
            }

            return string.Empty;
        }
    }
}