using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands;
using Restaurant.Application.Queries;
using Restaurant.Application.ViewModels;
using Restaurant.WebApi.Models;

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
            var command = _mapper.Map<CreateDishCommand>(createDishDto);
            var dishId = await Mediator.Send(command);

            return Ok(dishId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDishDto updateDishDto)
        {
            var command = _mapper.Map<UpdateDishCommand>(updateDishDto);
            command.Id = id;
            await Mediator.Send(command);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteDishCommand
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
            var query = new GetDishListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DishDetails>> GetById(Guid id)
        {
            var query = new GetDishByIdQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("categories/{id}")]
        public async Task<ActionResult<DishList>> GetByCategory(Guid id)
        {
            var query = new GetDishListByCategoryQuery
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
            var query = new GetDishListGroupedByCategoryQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpGet("published")]
        public async Task<ActionResult<CategoryList>> GetPublished()
        {
            var query = new GetPublishedDishListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
