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
    [Route("admin/dish")]
    public class AdminDishController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

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
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
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
