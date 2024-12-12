using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Order.Commands.Create;
using Restaurant.Application.Entities.Order.Commands.UpdateStatus;
using Restaurant.Application.Entities.Order.Queries.Get;
using Restaurant.Application.Entities.Order.Queries.GetById;
using Restaurant.Application.ViewModels;
using Restaurant.WebApi.Models.Order;

namespace Restaurant.WebApi.Controllers
{
    [Route("orders")]
    public class OrderController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [Authorize(Roles = "Client")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderDto dto)
        {
            var command = _mapper.Map<CreateCommand>(dto);
            command.UserId = UserId;

            var id = await Mediator.Send(command);

            return Ok(id);
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateOrderStatusDto dto)
        {
            var command = _mapper.Map<UpdateStatusCommand>(dto);
            command.Id = id;

            await Mediator.Send(command);

            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<OrderList>> Get()
        {
            var query = new GetQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetails>> GetById(Guid id)
        {
            var query = new GetByIdQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
