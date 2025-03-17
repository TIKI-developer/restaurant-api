using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Dish.Commands.Create;
using Restaurant.Application.Entities.Dish.Commands.Delete;
using Restaurant.Application.Entities.Dish.Commands.Update;
using Restaurant.Application.Entities.Dish.Queries.Get;
using Restaurant.Application.Entities.Dish.Queries.GetByCategory;
using Restaurant.Application.Entities.Dish.Queries.GetById;
using Restaurant.Application.Entities.Dish.Queries.GetGroupedByCategory;
using Restaurant.Application.Entities.Dish.Queries.GetPublished;
using Restaurant.Application.ViewModels;
using Restaurant.WebApi.Models.Dish;

namespace Restaurant.WebApi.Controllers
{
    [Route("dishes")]
    public class DishController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDishDto createDishDto)
        {
            var command = _mapper.Map<CreateCommand>(createDishDto);
            var dishId = await Mediator.Send(command);

            return Ok(dishId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDishDto updateDishDto)
        {
            var command = _mapper.Map<UpdateCommand>(updateDishDto);
            command.Id = id;
            await Mediator.Send(command);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<DishList>> Get()
        {
            var query = new GetQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DishDetails>> GetById(Guid id)
        {
            var query = new GetByIdQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("categories/{id}")]
        public async Task<ActionResult<DishList>> GetByCategory(Guid id)
        {
            var query = new GetByCategoryQuery
            {
                CategoryId = id
            };
            query.CategoryId = id;
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpGet("categories")]
        public async Task<ActionResult<DishListGroupedByCategory>> GetGroupedByCategory()
        {
            var query = new GetGroupedByCategoryQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpGet("published")]
        public async Task<ActionResult<CategoryList>> GetPublished()
        {
            var query = new GetPublishedQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
