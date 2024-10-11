using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Categories.Commands.CreateCategory;
using Restaurant.Application.Categories.Queries.GetCategoryList;
using Restaurant.Application.Categories.Commands.DeleteCategory;
using Restaurant.WebApi.Models;
using Restaurant.Application.Categories.Commands.UpdateCategory;

namespace Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<CategoryListViewModel>> GetAll()
        {
            var query = new GetCategoryListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryDto createCategory)
        {
            var command = _mapper.Map<CreateCategoryCommand>(createCategory);
            var categoryId = await Mediator.Send(command);

            return Ok(categoryId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDishDto updateCategoryDto)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(updateCategoryDto);
            await Mediator.Send(command);

            return NoContent();
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
