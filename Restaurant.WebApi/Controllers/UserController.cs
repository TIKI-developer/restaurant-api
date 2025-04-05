using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Order.Queries.GetByIdByUser;
using Restaurant.Application.Entities.Order.Queries.GetByUser;
using Restaurant.Application.Entities.User.Commands.Update;
using Restaurant.Application.Entities.User.Queries.GetById;
using Restaurant.Application.Entities.Address;
using Restaurant.Application.ViewModels;
using Restaurant.WebApi.Models.User;
using Restaurant.WebApi.Models.Address;

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
            var query = new GetByIdQuery
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
            var command = _mapper.Map<UpdateCommand>(dto);
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
            var query = new GetByUserQuery
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
            var query = new GetByIdByUserQuery
            {
                Id = id,
                UserId = UserId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpGet("addresses")]
        public async Task<ActionResult<AddressList>> GetAddresses()
        {
            var query = new Application.Entities.Address.Queries.GetByUser.GetByUserQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpGet("addresses/{id}")]
        public async Task<ActionResult<AddressDetails>> GetAddressBy(Guid id)
        {
            var query = new Application.Entities.Address.Queries.GetById.GetByIdQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpPost("addresses")]
        public async Task<IActionResult> CreateAddress([FromBody] AddAddressDto dto)
        {
            var command = _mapper.Map<Application.Entities.Address.Commands.AddAddress.AddAddressCommand>(dto);
            command.UserId = UserId;
            var id = await Mediator.Send(command);

            return Ok(id);
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpPut("addresses/{id}")]
        public async Task<IActionResult> UpdateAddress(Guid id, [FromBody] UpdateAddressDto dto)
        {
            var command = _mapper.Map<Application.Entities.Address.Commands.UpdateAddress.UpdateAddressCommand>(dto);
            command.Id = id;
            await Mediator.Send(command);

            return Ok();
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpDelete("addresses/{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            var command = new Application.Entities.Address.Commands.RemoveAddress.RemoveAddressCommand
            { 
                Id = id
            };
            await Mediator.Send(command);

            return Ok();
        }
    }
}
