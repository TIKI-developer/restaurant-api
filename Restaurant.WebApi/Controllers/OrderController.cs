using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Order.Commands.CreateOrder;
using Restaurant.Application.Entities.Order.Queries.GetOrderList;


namespace Restaurant.WebApi.Controllers
{
    [Route("orders")]
    [Authorize(Roles = "Client")]
    public class OrderController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<OrderListViewModel>> GetClientOrderList()
        {
            var query = new GetClientOrderListQuery
            {
                ClientId = UserId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create()
        {
            var command = new CreateOrderCommand
            { 
                ClientId = UserId
            };
            var id = await Mediator.Send(command);

            return Ok(id);
        }
    }
}
