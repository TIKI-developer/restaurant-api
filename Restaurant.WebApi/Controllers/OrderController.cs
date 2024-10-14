using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Orders.Commands.CreateOrder;
using Restaurant.WebApi.Models;

namespace Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateOrderDto order)
        {
            var command = _mapper.Map<CreateOrderCommand>(order);
            var orderId = await Mediator.Send(command);

            return Ok(orderId);
        }
        //[HttpGet("{ id }")]
        //public async Task<ActionResult<Order>> Get(Guid id)
        //{
        //    var query = new
        //    var vm = await Mediator.Send(query);
        //    return Ok(vm);
        //}
    }
}
