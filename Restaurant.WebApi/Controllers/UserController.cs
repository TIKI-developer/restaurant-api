using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Cart.Commands.CartAddDish;
using Restaurant.Application.Entities.Cart.Commands.CartDeleteDish;
using Restaurant.Application.Entities.Cart.Queries.GetCartDetails;
using Restaurant.Application.Entities.User.Commands.EditProfile;
using Restaurant.Application.Entities.User.Commands.Login;
using Restaurant.Application.Entities.User.Queries.GetUserDetails;
using Restaurant.WebApi.Models.User;

namespace Restaurant.WebApi.Controllers
{
    [Route("user")]
    public class UserController(IMapper mapper) : BaseController
    {
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
    }
}
