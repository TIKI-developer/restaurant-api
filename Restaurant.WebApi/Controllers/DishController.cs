using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Dishes.Commands.CreateDish;
using Restaurant.Application.Dishes.Commands.UpdateDish;
using Restaurant.Application.Dishes.Commands.DeleteDish;
using Restaurant.Application.Dishes.Queries.GetDishDetails;
using Restaurant.Application.Dishes.Queries.GetDishList;
using Restaurant.WebApi.Models;

namespace Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DishController : BaseController
    {
        private readonly IMapper _mapper;
        public DishController(IMapper mapper) => _mapper = mapper;

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
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDishDto createNoteDto)
        {
            var command = _mapper.Map<CreateDishCommand>(createNoteDto);
            var dishId = await Mediator.Send(command);

            return Ok(dishId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDishDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateDishCommand>(updateNoteDto);
            await Mediator.Send(command);

            return NoContent();
        }
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
    }
}
