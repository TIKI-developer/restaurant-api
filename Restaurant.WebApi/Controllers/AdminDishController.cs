using AutoMapper;
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
    public class AdminDishController(IMapper mapper, FileLoader fileLoader) : BaseController
    {
        private readonly FileLoader _fileLoader = fileLoader;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateDishDto createDishDto)
        {
            var command = _mapper.Map<CreateDishCommand>(createDishDto);
            var fileNames = new List<string>();

            foreach (var file in createDishDto.Images)
            {
                if (file.Length > 0)
                {
                    fileNames.Add(_fileLoader.SaveFile(file, "Images/"));
                }
            }
            command.Images = fileNames;
            var dishId = await Mediator.Send(command);

            return Ok(dishId);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] UpdateDishDto updateDishDto)
        {
            var command = _mapper.Map<UpdateDishCommand>(updateDishDto);
            command.Id = id;
            var fileNames = new List<string>();

            foreach (var file in updateDishDto.Images)
            {
                if (file.Length > 0)
                {
                    fileNames.Add(_fileLoader.SaveFile(file, "Images/"));
                }
            }
            command.Images = fileNames;
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
