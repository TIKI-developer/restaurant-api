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
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDetailsViewModel>> Get(Guid id)
        {
            var query = new GetCartDetailsQuery
            {
                ClientId = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [Authorize]
        [HttpPut("edit")]
        public async Task<IActionResult> Update([FromBody] UpdateCartCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
