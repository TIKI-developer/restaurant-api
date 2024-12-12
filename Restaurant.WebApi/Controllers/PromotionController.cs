using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Promotion.Command.Create;
using Restaurant.Application.Entities.Promotion.Command.Delete;
using Restaurant.Application.Entities.Promotion.Command.Update;
using Restaurant.Application.Entities.Promotion.Queries.Get;
using Restaurant.Application.Entities.Promotion.Queries.GetById;
using Restaurant.Application.Entities.Promotion.Queries.GetPublished;
using Restaurant.Application.ViewModels;
using Restaurant.WebApi.Models.Promotion;

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
            var command = _mapper.Map<CreateCommand>(dto);
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdatePromotionDto dto)
        {
            var command = _mapper.Map<UpdateCommand>(dto);
            command.Id = id;
            await Mediator.Send(command);

            return Ok(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteCommand { Id = id };
            await Mediator.Send(command);

            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionDetails>> GetById(Guid id)
        {
            var query = new GetByIdQuery { Id = id };
            var promotion = await Mediator.Send(query);

            return Ok(promotion);
        }
        [HttpGet]
        public async Task<ActionResult<PromotionList>> Get()
        {
            var query = new GetQuery();
            var promotionsVm = await Mediator.Send(query);

            return Ok(promotionsVm);
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
