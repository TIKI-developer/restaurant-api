using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Category.Commands.CreateCategory;
using Restaurant.Application.Entities.Category.Commands.DeleteCategory;
using Restaurant.Application.Entities.Category.Commands.UpdateCategory;
using Restaurant.WebApi.Models.Category;

namespace Restaurant.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("admin/category")]
    public class AdminCategoryController(IMapper mapper, FileLoader fileLoader) : BaseController
    {
        private readonly FileLoader _fileLoader = fileLoader;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateCategoryDto createCategory)
        {
            var command = _mapper.Map<CreateCategoryCommand>(createCategory);

            if (createCategory.Image != null && createCategory.Image.Length > 0)
            {
                var fileName = _fileLoader.SaveFile(createCategory.Image, "Images/"); ;
                command.Image = fileName;
            }
            
            var categoryId = await Mediator.Send(command);

            return Ok(categoryId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromForm] UpdateCategoryDto updateCategoryDto)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(updateCategoryDto);
            if (updateCategoryDto.Image != null && updateCategoryDto.Image.Length > 0)
            {
                var fileName = _fileLoader.SaveFile(updateCategoryDto.Image, "Images/");
                command.Image = fileName;
            }

            command.Id = id;

            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCategoryCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
