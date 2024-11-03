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
    public class AdminCategoryController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateCategoryDto createCategory)
        {
            var command = _mapper.Map<CreateCategoryCommand>(createCategory);

            if (createCategory.Image != null && createCategory.Image.Length > 0)
            {
                var fileName = SaveFile(createCategory.Image);
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
                var fileName = SaveFile(updateCategoryDto.Image);
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
        private string SaveFile(IFormFile file)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads/Categories");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return uniqueFileName;
        }
    }
}
