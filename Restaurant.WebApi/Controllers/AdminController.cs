using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.User.Commands.RegisterAdmin;
using Restaurant.WebApi.Models.User;

namespace Restaurant.WebApi.Controllers
{
    [Route("admin")]
    public class AdminController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost("signup")]
        public async Task<ActionResult<Guid>> RegisterAdmin([FromBody] AdminRegisterDto userRegisterDto)
        {
            var command = _mapper.Map<RegisterAdminCommand>(userRegisterDto);
            var userId = await Mediator.Send(command);

            return Ok(userId);
        }
    }
}
