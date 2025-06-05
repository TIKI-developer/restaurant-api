using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Restaurant.Application.Commands;
using Restaurant.Verification;
using Restaurant.WebApi.Models;
using System.Text.RegularExpressions;

namespace Restaurant.WebApi.Controllers
{
    [Route("auth")]
    public class AuthController(IMapper mapper, IOptions<SmsRuOptions> options) : BaseController
    {
        private readonly SmsRuOptions _smsRuOptions = options.Value;
        private readonly IMapper _mapper = mapper;

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginDto dto)
        {
            dto.PhoneNumber = NormalizePhoneNumber(dto.PhoneNumber);
            Console.WriteLine(dto.PhoneNumber);
            var command = _mapper.Map<LoginCommand>(dto);
            var token = await Mediator.Send(command);

            return Ok(token);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await Task.Run(() =>
            {
                HttpContext.Response.Cookies.Delete("creeper");
            });

            return Ok();
        }
        [HttpPost("verify")]
        public async Task<IActionResult> Verify([FromForm] string[] data, [FromForm] string hash)
        {
            var command = new VerifyNumberCommand { Data = data, Hash = hash };
            await Mediator.Send(command);

            return Ok(100);
        }
        [HttpPost("verify/prepare")]
        public async Task<IActionResult> PrepareVerify([FromBody] PreparePhoneNumberVerificationDto dto)
        {
            dto.PhoneNumber = NormalizePhoneNumber(dto.PhoneNumber);
            var url = "https://sms.ru/callcheck/add";

            var requestData = new Dictionary<string, string>
            {
                { "api_id", _smsRuOptions.ApiKey },
                { "phone", dto.PhoneNumber },
                { "json", "1" }
            };

            using var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.PostAsync(url, new FormUrlEncodedContent(requestData));

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return BadRequest(new { message = "Ошибка при отправке запроса", details = error });
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PreparePhoneNumberVerificationResponse>(jsonResponse);

                if (result != null && result.Status == "OK")
                {
                    var command = new PrepareVerificationPhoneNumberCommand
                    {
                        Number = dto.PhoneNumber,
                        CheckId = result.CheckId
                    };

                    await Mediator.Send(command);

                    return Ok(new
                    {
                        result.CallNumber,
                        result.CallNumberPretty,
                        result.CallNumberHtml
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        result?.StatusCode,
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Произошла ошибка", details = ex.Message });
            }
        }
        [HttpPost("code/call")]
        public async Task<IActionResult> CodeCall([FromBody] CodeCallDto dto)
        {
            dto.UserPhoneNumber = NormalizePhoneNumber(dto.UserPhoneNumber);
            var url = "https://sms.ru/code/call";
            var clientIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? Request.Headers["X-Forwarded-For"].ToString();

            var requestData = new Dictionary<string, string>
            {
                { "api_id", _smsRuOptions.ApiKey },
                { "phone", dto.UserPhoneNumber },
                { "ip",  clientIp }
            };

            using var httpClient = new HttpClient();
            try
            {
                var response = await httpClient.PostAsync(url, new FormUrlEncodedContent(requestData));

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return BadRequest(new { message = "Ошибка при отправке запроса", details = error });
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CodeCallResponse>(jsonResponse);

                if (result != null && result.Status == "OK")
                {
                    var command = new CodeCallCommand
                    {
                        PhoneNumber = dto.UserPhoneNumber,
                        Code = result.Code,
                        CallId = result.CallId
                    };

                    await Mediator.Send(command);

                    return Ok();
                }
                else
                {
                    return BadRequest(new
                    {
                        result?.Status,
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Произошла ошибка", details = ex.Message });
            }
        }
        private static string NormalizePhoneNumber(string? phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber)) return "";

            phoneNumber = Regex.Replace(phoneNumber, @"\D", "");

            if (phoneNumber.StartsWith("89"))
            {
                return "+7" + phoneNumber[1..];
            }

            if (phoneNumber.StartsWith("7"))
            {
                return "+7" + phoneNumber[1..];
            }

            if (phoneNumber.StartsWith("+7"))
            {
                return phoneNumber; // Уже правильный формат
            }

            return phoneNumber;
        }

        public class NotificationData
        {
            [FromForm(Name = "data")]
            public required string[] Data { get; set; }
        }
    }
}
