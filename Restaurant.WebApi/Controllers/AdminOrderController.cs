using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Order.Commands.UpdateOrderStatus;
using Restaurant.Application.Entities.Order.Queries.GetOrder;
using Restaurant.Application.Entities.Order.Queries.GetOrderList;
using Restaurant.WebApi.Models.Order;

namespace Restaurant.WebApi.Controllers
{
    [Route("admin/orders")]
    [Authorize(Roles = "Admin")]
    public class AdminOrderController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<OrderListViewModel>> GetOrderList()
        {
            var query = new GetOrderListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderStatus(Guid id, [FromBody] UpdateOrderStatusDto dto)
        {
            var command = _mapper.Map<UpdateOrderStatusCommand>(dto);
            command.Id = id;

            await Mediator.Send(command);

            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderViewModel>> GetOrderDetails(Guid id)
        {
            var query = new GetOrderQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
