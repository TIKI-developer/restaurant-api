using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands;
using Restaurant.Application.Queries;
using Restaurant.Application.ViewModels;
using Restaurant.WebApi.Models;

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
            var command = _mapper.Map<CreateOrderCommand>(dto);
            command.UserId = UserId;

            var id = await Mediator.Send(command);

            return Ok(id);
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateOrderStatusDto dto)
        {
            var command = _mapper.Map<UpdateOrderStatusCommand>(dto);
            command.Id = id;

            await Mediator.Send(command);

            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<OrderList>> Get([FromQuery] OrderListFilterDto? filter)
        {
            var query = new GetOrderListQuery
            {
                ByLastDays = filter?.LastDays,
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetails>> GetById(Guid id)
        {
            var query = new GetOrderByIdQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
