using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands;
using Restaurant.Application.Queries;
using Restaurant.Application.ViewModels;
using Restaurant.WebApi.Models;

namespace Restaurant.WebApi.Controllers
{
    [Route("promotions")]
    public class PromotionController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePromotionDto dto)
        {
            var command = _mapper.Map<CreatePromotionCommand>(dto);
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdatePromotionDto dto)
        {
            var command = _mapper.Map<UpdatePromotionCommand>(dto);
            command.Id = id;
            await Mediator.Send(command);

            return Ok(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeletePromotionCommand { Id = id };
            await Mediator.Send(command);

            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionDetails>> GetById(Guid id)
        {
            var query = new GetPromotionByIdQuery { Id = id };
            var promotion = await Mediator.Send(query);

            return Ok(promotion);
        }
        [HttpGet]
        public async Task<ActionResult<PromotionList>> Get()
        {
            var query = new GetPromotionListQuery();
            var promotionsVm = await Mediator.Send(query);

            return Ok(promotionsVm);
        }
        [HttpGet("published")]
        public async Task<ActionResult<CategoryList>> GetPublished()
        {
            var query = new GetPublishedPromotionListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpGet("advanced")]
        public async Task<ActionResult<CategoryList>> GetAdvanced()
        {
            var query = new GetAdvancedPromotionListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
