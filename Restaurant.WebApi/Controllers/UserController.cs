using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands;
using Restaurant.Application.Queries;
using Restaurant.Application.ViewModels;
using Restaurant.WebApi.Models;

namespace Restaurant.WebApi.Controllers
{
    [Route("users")]
    public class UserController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [Authorize(Roles = "Client, Admin")]
        [HttpGet("profile")]
        public async Task<ActionResult<UserDetails>> GetProfile()
        {
            var query = new GetUserByIdQuery
            {
                Id = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpPut("profile")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto dto)
        {
            var command = _mapper.Map<UpdateUserProfileCommand>(dto);
            command.Id = UserId;

            await Mediator.Send(command);

            return NoContent();
        }
        [HttpGet("role")]
        public async Task<ActionResult<string>> GetRole()
        {
            await Task.Run(() =>
            {
                return Ok(UserRole);
            });
            return Ok(UserRole);
        }
        [Authorize(Roles = "Client")]
        [HttpGet("orders")]
        public async Task<ActionResult<OrderList>> GetByUser()
        {
            var query = new GetOrderByUserQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [Authorize(Roles = "Client")]
        [HttpGet("orders/{id}")]
        public async Task<ActionResult<OrderDetails>> GetUserOrder(Guid id)
        {
            var query = new GetOrderByIdByUserQuery
            {
                Id = id,
                UserId = UserId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpGet("addresses")]
        public async Task<ActionResult<SavedAddressList>> GetAddresses()
        {
            var query = new GetSavedAddressListByUserQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpGet("addresses/{id}")]
        public async Task<ActionResult<SavedAddressDetails>> GetAddressBy(Guid id)
        {
            var query = new GetSavedAddressByIdQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpPost("addresses")]
        public async Task<IActionResult> CreateAddress([FromBody] AddSavedAddressDto dto)
        {
            var command = _mapper.Map<AddSavedAddressCommand>(dto);
            command.UserId = UserId;
            var id = await Mediator.Send(command);

            return Ok(id);
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpPut("addresses/{id}")]
        public async Task<IActionResult> UpdateAddress(Guid id, [FromBody] UpdateSavedAddressDto dto)
        {
            var command = _mapper.Map<UpdateSavedAddressCommand>(dto);
            command.Id = id;
            await Mediator.Send(command);

            return Ok();
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpDelete("addresses/{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            var command = new DeleteSavedAddressCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return Ok();
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpPatch("addresses/set-default")]
        public async Task<IActionResult> SetDefaultAddress([FromBody] UpdateUserDefaultAddressDto dto)
        {
            var command = _mapper.Map<UpdateUserDefaultAddressCommand>(dto);
            command.UserId = UserId;
            await Mediator.Send(command);

            return Ok();
        }
    }
}
