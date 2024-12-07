using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Order.Commands.CreateOrder;
using Restaurant.Application.Entities.Order.Queries.GetOrder;
using Restaurant.Application.Entities.Order.Queries.GetOrderList;
using Restaurant.WebApi.Models.Order;


namespace Restaurant.WebApi.Controllers
{
    [Route("orders")]
    [Authorize(Roles = "Client, Admin")]
    public class OrderController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<OrderListViewModel>> GetUserOrderList()
        {
            var query = new GetUserOrderListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderListViewModel>> GetUserOrder(Guid id)
        {
            var query = new GetOrderDetailsByUserQuery
            {
                Id = id,
                UserId = UserId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderDto dto)
        {
            var command = _mapper.Map<CreateOrderCommand>(dto);
            command.UserId = UserId;

            var id = await Mediator.Send(command);

            return Ok(id);
        }
    }
}
