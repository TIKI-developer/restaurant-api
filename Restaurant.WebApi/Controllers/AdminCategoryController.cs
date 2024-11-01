using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Category.Commands.CreateCategory;
using Restaurant.Application.Entities.Category.Commands.DeleteCategory;
using Restaurant.Application.Entities.Category.Commands.UpdateCategory;
using Restaurant.WebApi.Models.Category;

namespace Restaurant.WebApi.Controllers
{
    [Route("admin/category")]
    public class AdminCategoryController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryDto createCategory)
        {
            var command = _mapper.Map<CreateCategoryCommand>(createCategory);
            var categoryId = await Mediator.Send(command);

            return Ok(categoryId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryDto)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(updateCategoryDto);
            await Mediator.Send(command);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
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
