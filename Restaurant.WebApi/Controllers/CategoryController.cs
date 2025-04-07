using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands;
using Restaurant.Application.Queries;
using Restaurant.Application.ViewModels;
using Restaurant.WebApi.Models;

namespace Restaurant.WebApi.Controllers
{
    [Route("categories")]
    public class CategoryController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryDto createCategory)
        {
            var command = _mapper.Map<CreateCategoryCommand>(createCategory);

            var categoryId = await Mediator.Send(command);

            return Ok(categoryId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(updateCategoryDto);

            command.Id = id;

            await Mediator.Send(command);

            return Ok();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetails>> GetById(Guid id)
        {
            var query = new GetCategoryByIdQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<CategoryList>> Get()
        {
            var query = new GetCategoryListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("published")]
        public async Task<ActionResult<CategoryList>> GetPublished()
        {
            var query = new GetPublishedCategoryListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
