using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Dish.Commands.DeleteDish;
using Restaurant.Application.Entities.Dish.Queries.GetDishDetails;
using Restaurant.Application.Entities.Dish.Queries.GetDishList;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Application.Entities.Dish.Commands.CreateDish;
using Restaurant.Application.Entities.Dish.Commands.UpdateDish;
using Restaurant.WebApi.Models.Dish;


namespace Restaurant.WebApi.Controllers
{
    [Route("api/dish")]
    public class DishController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [Authorize(Roles = "Admin, Client")]
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
        [Authorize(Roles = "Admin, Client")]
        [HttpGet("list")]
        public async Task<ActionResult<DishListViewModel>> GetAll()
        {
            var query = new GetDishListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDishDto createDishDro)
        {
            var command = _mapper.Map<CreateDishCommand>(createDishDro);
            var dishId = await Mediator.Send(command);

            return Ok(dishId);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateDishDto updateDishDto)
        {
            var command = _mapper.Map<UpdateDishCommand>(updateDishDto);
            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteDishCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [Authorize(Roles = "Admin, Client")]
        [HttpGet("list/{categoryId}")]
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
