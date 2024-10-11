using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Dishes.Commands.CreateDish;
using Restaurant.Application.Dishes.Commands.UpdateDish;
using Restaurant.Application.Dishes.Commands.DeleteDish;
using Restaurant.Application.Dishes.Queries.GetDishDetails;
using Restaurant.Application.Dishes.Queries.GetDishList;
using Restaurant.WebApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DishController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<DishListViewModel>> GetAll()
        {
            var query = new GetDishListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
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
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDishDto createDishDro)
        {
            var command = _mapper.Map<CreateDishCommand>(createDishDro);
            var dishId = await Mediator.Send(command);

            return Ok(dishId);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateDishDto updateDishDto)
        {
            var command = _mapper.Map<UpdateDishCommand>(updateDishDto);
            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteDishCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
