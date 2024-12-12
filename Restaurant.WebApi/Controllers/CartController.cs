using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Cart.Commands.AddDish;
using Restaurant.Application.Entities.Cart.Commands.DeleteDish;
using Restaurant.Application.Entities.Cart.Queries.GetDetails;
using Restaurant.Application.ViewModels;

namespace Restaurant.WebApi.Controllers
{
    [Route("carts")]
    public class CartController : BaseController
    {
        [Authorize(Roles = "Client, Admin")]
        [HttpPatch("dishes/{id}")]
        public async Task<IActionResult> AddDish(Guid id)
        {
            var command = new AddDishCommand
            {
                UserId = UserId,
                DishId = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpDelete("dishes/{id}")]
        public async Task<IActionResult> RemoveDish(Guid id)
        {
            var command = new DeleteDishCommand
            {
                UserId = UserId,
                DishId = id
            };

            await Mediator.Send(command);

            return NoContent();
        }
        [Authorize(Roles = "Client, Admin")]
        [HttpGet]
        public async Task<ActionResult<CartDetails>> Get()
        {
            var query = new GetByUserQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
