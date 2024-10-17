using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Order.Commands.CreateOrder;
using Restaurant.Application.Entities.Order.Queries.GetClientOrderList;
using Restaurant.Domain.Order;

namespace Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<OrderListViewModel>> GetOrderList([FromBody] GetClientOrderListQuery query)
        {
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
