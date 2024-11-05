using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Dish.Queries.GetDishDetails;
using Restaurant.Application.Entities.Dish.Queries.GetDishList;

namespace Restaurant.WebApi.Controllers
{
    [Route("dishes")]
    //[Authorize(Roles = "Admin, Client")]
    public class DishController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<DishDetailsViewModel>> Get(Guid id)
        {
            var query = new GetDishDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        public async Task<ActionResult<DishListViewModel>> GetAll()
        {
            var query = new GetDishListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<DishListViewModel>> GetDishesWithCategory(Guid categoryId)
        {
            var query = new GetCategoryDishListQuery
            {
                CategoryId = categoryId
            };
            query.CategoryId = categoryId;
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
