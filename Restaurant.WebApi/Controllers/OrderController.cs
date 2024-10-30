using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Order.Commands.CreateOrder;
using Restaurant.Application.Entities.Order.Queries.GetOrderList;


namespace Restaurant.WebApi.Controllers
{
    [Route("api/order")]
    public class OrderController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [Authorize(Roles = "Client")]
        [HttpGet("list")]
        public async Task<ActionResult<OrderListViewModel>> GetClientOrderList()
        {
            var clientId = Guid.Parse(User.FindFirst("userId")?.Value);

            var query = new GetClientOrderListQuery
            {
                ClientId = clientId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("admin/all")]
        public async Task<ActionResult<OrderListViewModel>> GetOrderList()
        {
            var query = new GetOrderListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [Authorize(Roles = "Client")]
        [HttpGet("create")]
        public async Task<ActionResult<Guid>> Create()
        {
            var clientId = Guid.Parse(User.FindFirst("userId")?.Value);

            var command = new CreateOrderCommand
            { 
                ClientId = clientId 
            };
            command.ClientId = clientId;
            var id = await Mediator.Send(command);

            return Ok(id);
        }
    }
}
