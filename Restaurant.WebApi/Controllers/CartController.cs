using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Cart.Commands.UpdateCart;
using Restaurant.Application.Entities.Cart.Queries.GetCartDetails;
using Restaurant.Domain.Cart;

namespace Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CartController : BaseController
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<CartModel>> Get([FromBody] GetCartDetailsQuery query)
        {
            var vm = Mediator.Send(query);
            return Ok(vm);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCartCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
