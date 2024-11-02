using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Dish.Commands.CreateDish;
using Restaurant.Application.Entities.Dish.Commands.DeleteDish;
using Restaurant.Application.Entities.Dish.Commands.UpdateDish;
using Restaurant.WebApi.Models.Dish;

namespace Restaurant.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("admin/dish")]
    public class AdminDishController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDishDto createDishDro)
        {
            var command = _mapper.Map<CreateDishCommand>(createDishDro);
            var dishId = await Mediator.Send(command);

            return Ok(dishId);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDishDto updateDishDto)
        {
            var command = _mapper.Map<UpdateDishCommand>(updateDishDto);
            command.Id = id;

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
