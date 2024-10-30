using Restaurant.Application.Entities.Cart.Commands.CartAddDish;
using Restaurant.Application.Entities.Cart.Queries.GetCartDetails;
using Restaurant.Application.Entities.User.Commands.EditProfile;
using Restaurant.Application.Entities.User.Commands.Login;
using Restaurant.Application.Entities.User.Commands.RegisterClient;
using Restaurant.Application.Entities.User.Queries.GetUserDetails;
using Microsoft.AspNetCore.Authorization;
using Restaurant.WebApi.Models.User;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Restaurant.Application.Entities.Cart.Commands.CartDeleteDish;
using Restaurant.Application.Entities.User.Commands.RegisterAdmin;

namespace Restaurant.WebApi.Controllers
{
    [Route("api/user")]
    public class UserController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost("signup")]
        public async Task<ActionResult<Guid>> Register([FromBody] ClientRegisterDto userRegisterDto)
        {
            var command = _mapper.Map<RegisterClientCommand>(userRegisterDto);
            var userId = await Mediator.Send(command);

            return Ok(userId);
        }
        [HttpPost("admin/signup")]
        public async Task<ActionResult<Guid>> RegisterAdmin([FromBody] AdminRegisterDto userRegisterDto)
        {
            var command = _mapper.Map<RegisterAdminCommand>(userRegisterDto);
            var userId = await Mediator.Send(command);

            return Ok(userId);
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginDto userLoginDto)
        {
            var command = _mapper.Map<LoginUserCommand>(userLoginDto);
            var token = await Mediator.Send(command);

            HttpContext.Response.Cookies.Append("creeper", token);

            return Ok(token);
        }
        [Authorize(Roles = "Client")]
        [HttpGet("profile")]
        public async Task<ActionResult<UserDetailsViewModel>> GetProfile()
        {
            var userId = Guid.Parse(User.FindFirst("userId")?.Value);

            var query = new GetUserDetailsQuery
            {
                Id = userId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [Authorize(Roles = "Client")]
        [HttpPut("profile/edit")]
        public async Task<IActionResult> Update([FromBody] EditClientProfileDto dto)
        {
            var command = _mapper.Map<EditProfileCommand>(dto);
            command.Id = Guid.Parse(User.FindFirst("userId")?.Value);

            await Mediator.Send(command);

            return NoContent();
        }
        [Authorize(Roles = "Client")]
        [HttpGet("cart")]
        public async Task<ActionResult<CartDetailsViewModel>> GetCart()
        {
            var userId = Guid.Parse(User.FindFirst("userId")?.Value);

            var query = new GetCartDetailsQuery
            {
                ClientId = userId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [Authorize(Roles = "Client")]
        [HttpPut("cart/add")]
        public async Task<IActionResult> AddDish([FromBody] CartAddDishDto dto)
        {
            var command = _mapper.Map<CartAddDishCommand>(dto);
            command.ClientId = Guid.Parse(User.FindFirst("userId")?.Value);
            await Mediator.Send(command);

            return NoContent();
        }
        [Authorize(Roles = "Client")]
        [HttpDelete("cart/delete")]
        public async Task<IActionResult> RemoveDish([FromBody] CartDeleteDishDto dto)
        {
            var command = _mapper.Map<CartDeleteDishCommand>(dto);
            command.UserId = Guid.Parse(User.FindFirst("userId")?.Value);
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
