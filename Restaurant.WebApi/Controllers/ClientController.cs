using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Cart.Commands.CartAddDish;
using Restaurant.Application.Entities.Cart.Commands.CartDeleteDish;
using Restaurant.Application.Entities.Cart.Queries.GetCartDetails;
using Restaurant.Application.Entities.User.Commands.EditProfile;
using Restaurant.Application.Entities.User.Commands.Login;
using Restaurant.Application.Entities.User.Commands.RegisterClient;
using Restaurant.Application.Entities.User.Queries.GetUserDetails;
using Restaurant.WebApi.Models.User;

namespace Restaurant.WebApi.Controllers
{
    [Route("client")]
    public class ClientController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost("auth/signup")]
        public async Task<ActionResult<Guid>> Register([FromBody] ClientRegisterDto userRegisterDto)
        {
            var command = _mapper.Map<RegisterClientCommand>(userRegisterDto);
            var userId = await Mediator.Send(command);

            return Ok(userId);
        }
        [HttpPost("auth/login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginDto userLoginDto)
        {
            var command = _mapper.Map<LoginUserCommand>(userLoginDto);
            var token = await Mediator.Send(command);

            HttpContext.Response.Cookies.Append("creeper", token);

            return Ok(token);
        }
        [Authorize(Roles = "Client")]
        [HttpGet("profile")]
        public async Task<ActionResult<ClientDetailsViewModel>> GetProfile()
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
        [HttpPut("profile")]
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
        [HttpPut("cart")]
        public async Task<IActionResult> AddDish([FromBody] CartAddDishDto dto)
        {
            var command = _mapper.Map<CartAddDishCommand>(dto);
            command.ClientId = Guid.Parse(User.FindFirst("userId")?.Value);
            await Mediator.Send(command);

            return NoContent();
        }
        [Authorize(Roles = "Client")]
        [HttpDelete("cart/{dishId}")]
        public async Task<IActionResult> RemoveDish(Guid dishId)
        {
            var userId = Guid.Parse(User.FindFirst("userId")?.Value);

            var command = new CartDeleteDishCommand
            { 
                UserId = userId,
                DishId = dishId 
            };
            
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
