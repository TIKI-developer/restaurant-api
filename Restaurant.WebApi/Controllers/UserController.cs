using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Restaurant.Application.Entities.Cart.Commands.CartAddDish;
using Restaurant.Application.Entities.Cart.Commands.CartDeleteDish;
using Restaurant.Application.Entities.Cart.Queries.GetCartDetails;
using Restaurant.Application.Entities.User.Commands.EditProfile;
using Restaurant.Application.Entities.User.Commands.Login;
using Restaurant.Application.Entities.User.Commands.VerifyNumber;
using Restaurant.Application.Entities.User.Queries.GetUserDetails;
using Restaurant.Verification;
using Restaurant.WebApi.Models.User;

namespace Restaurant.WebApi.Controllers
{
    [Route("user")]
    public class UserController(IMapper mapper, IOptions<SmsRuOptions> options) : BaseController
    {
        private readonly SmsRuOptions _smsRuOptions = options.Value;
        private readonly IMapper _mapper = mapper;

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginDto userLoginDto)
        {
            var command = _mapper.Map<LoginCommand>(userLoginDto);
            var token = await Mediator.Send(command);

            return Ok(token);
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpGet("profile")]
        public async Task<ActionResult<UserDetailsViewModel>> GetProfile()
        {
            var query = new GetUserDetailsQuery
            {
                Id = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpPut("profile")]
        public async Task<IActionResult> Update([FromBody] EditUserProfileDto dto)
        {
            var command = _mapper.Map<EditProfileCommand>(dto);
            command.Id = UserId;

            await Mediator.Send(command);

            return NoContent();
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpGet("cart")]
        public async Task<ActionResult<CartDetailsViewModel>> GetCart()
        {
            var query = new GetCartDetailsQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpPut("cart")]
        public async Task<IActionResult> AddDish([FromBody] CartAddDishDto dto)
        {
            var command = _mapper.Map<CartAddDishCommand>(dto);
            command.UserId = UserId;
            await Mediator.Send(command);

            return NoContent();
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpDelete("cart/{dishId}")]
        public async Task<IActionResult> RemoveDish(Guid dishId)
        {
            var command = new CartDeleteDishCommand
            {
                UserId = UserId,
                DishId = dishId
            };

            await Mediator.Send(command);

            return NoContent();
        }
        [HttpGet("role")]
        public ActionResult<string> GetRole()
        {
            return Ok(UserRole);
        }
        [HttpPost("verify")]
        public async Task<IActionResult> Verify([FromForm] NotificationData data)
        {
            foreach (var item in data.Data)
            {
                Console.WriteLine(item);
            }

            var command = new VerifyNumberCommand { Data = data.Data };
            await Mediator.Send(command);

            return Ok(100);
        }
        public class NotificationData
        {
            [FromForm(Name = "data")]
            public required string[] Data { get; set; }
        }
        [HttpPost("verify/prepare")]
        public async Task<IActionResult> PrepareVerify([FromBody] PrepareNumberVerifyDto dto)
        {
            var url = "https://sms.ru/callcheck/add";

            var requestData = new Dictionary<string, string>
            {
                { "api_id", _smsRuOptions.ApiKey },
                { "phone", dto.NumberPhone },
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
                var result = JsonConvert.DeserializeObject<VerifyResponse>(jsonResponse);

                if (result != null && result.Status == "OK")
                {
                    var command = new PrepareVerifyNumberCommand
                    {
                        Number = dto.NumberPhone,
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
    }
}
