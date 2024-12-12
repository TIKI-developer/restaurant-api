using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Category.Commands.Create;
using Restaurant.Application.Entities.Category.Commands.Delete;
using Restaurant.Application.Entities.Category.Commands.Update;
using Restaurant.Application.Entities.Category.Queries.Get;
using Restaurant.Application.Entities.Category.Queries.GetById;
using Restaurant.Application.ViewModels;
using Restaurant.WebApi.Models.Category;

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
            var command = _mapper.Map<CreateCommand>(createCategory);

            var categoryId = await Mediator.Send(command);

            return Ok(categoryId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var command = _mapper.Map<UpdateCommand>(updateCategoryDto);

            command.Id = id;

            await Mediator.Send(command);

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCommand
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
            var query = new GetByIdQuery
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
            var query = new GetQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("published")]
        public async Task<ActionResult<CategoryList>> GetPublished()
        {
            var query = new GetPublishedQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
