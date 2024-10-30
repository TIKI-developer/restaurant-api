using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Category.Commands.CreateCategory;
using Restaurant.Application.Entities.Category.Commands.DeleteCategory;
using Restaurant.Application.Entities.Category.Commands.UpdateCategory;
using Restaurant.Application.Entities.Category.Queries.GetCategory;
using Restaurant.Application.Entities.Category.Queries.GetCategoryList;
using Restaurant.WebApi.Models.Category;


namespace Restaurant.WebApi.Controllers
{
    [Route("api/category")]
    public class CategoryController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [Authorize(Roles = "Admin, Client")]
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailsViewModel>> Get(Guid id)
        {
            var query = new GetCategoryQuery
            { 
                Id = id 
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [Authorize(Roles = "Admin, Client")]
        [HttpGet("list")]
        public async Task<ActionResult<CategoryListViewModel>> GetCategoryList()
        {
            var query = new GetCategoryListQuery();

            var vm = await Mediator.Send(query);
             
            return Ok(vm);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("admin/create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryDto createCategory)
        {
            var command = _mapper.Map<CreateCategoryCommand>(createCategory);
            var categoryId = await Mediator.Send(command);

            return Ok(categoryId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("admin/update")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryDto)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(updateCategoryDto);
            await Mediator.Send(command);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("admin/delete/{id}")]
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
