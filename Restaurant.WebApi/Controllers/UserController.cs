using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Cart.Commands.UpdateCart;
using Restaurant.Application.Entities.User.Commands.Login;
using Restaurant.Application.Entities.User.Commands.Register;
using Restaurant.Application.Entities.User.Queries.GetUserDetails;
using Restaurant.WebApi.Models.User;

namespace Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost("signup")]
        public async Task<ActionResult<Guid>> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            var command = _mapper.Map<RegisterUserCommand>(userRegisterDto);
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
        [Authorize]
        [HttpGet("profile")]
        public async Task<ActionResult<UserDetailsViewModel>> GetProfile([FromBody] GetUserProfileDto getUserProfileDto)
        {
            var query = new GetUserDetailsQuery
            {
                Id = getUserProfileDto.Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [Authorize]
        [HttpGet("cart")]
        public async Task<ActionResult<UserEditDto>> GetCart()
        {   
            return Ok();
        }

        //[Authorize]
        //[HttpPut("edit")]
        //public async Task<IActionResult> Update([FromBody] UpdateCartCommand command)
        //{
        //    await Mediator.Send(command);

        //    return NoContent();
        //}
    }
}
