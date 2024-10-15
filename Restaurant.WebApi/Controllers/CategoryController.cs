using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Category.Queries.GetCategoryList;
using Restaurant.Application.Entities.Category.Commands.DeleteCategory;
using Restaurant.Application.Entities.Category.Commands.CreateCategory;
using Restaurant.Application.Entities.Category.Commands.UpdateCategory;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Domain.Category;
using Restaurant.WebApi.Models.Category;
using Restaurant.WebApi.Models.Dish;
using Restaurant.Application.Entities.Category.Queries.GetCategory;


namespace Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryDto createCategory)
        {
            var command = _mapper.Map<CreateCategoryCommand>(createCategory);
            var categoryId = await Mediator.Send(command);

            return Ok(categoryId);
        }
        [HttpGet]
        public async Task<ActionResult<CategoryModel>> Get([FromBody] GetCategoryQuery query)
        {
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("all")]
        public async Task<ActionResult<CategoryListViewModel>> GetCategoryList()
        {
            var query = new GetCategoryListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDishDto updateCategoryDto)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(updateCategoryDto);
            await Mediator.Send(command);

            return NoContent();
        }
        [Authorize]
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
