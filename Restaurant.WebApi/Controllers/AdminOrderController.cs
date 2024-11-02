using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Order.Queries.GetOrderList;

namespace Restaurant.WebApi.Controllers
{
    [Route("admin/orders")]
    [Authorize(Roles = "Admin")]
    public class AdminOrderController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<OrderListViewModel>> GetOrderList()
        {
            var query = new GetOrderListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
