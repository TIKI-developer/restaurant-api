using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Users.Commands.CreateUser;
using Restaurant.Application.Users.Commands.Login;
using Restaurant.Application.Users.Queries.GetUserDetails;
using Restaurant.WebApi.Models;

namespace Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost("register")]
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
        [HttpGet("profile")]
        public async Task<ActionResult<UserDetailsViewModel>> Get([FromBody] GetUserProfileDto getUserProfileDto)
        {
            var query = new GetUserDetailsQuery
            {
                Id = getUserProfileDto.Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
