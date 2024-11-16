using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Promotion.Command.CreatePromotion;
using Restaurant.Application.Entities.Promotion.Command.DeletePromotion;
using Restaurant.Application.Entities.Promotion.Command.UpdatePromotion;
using Restaurant.WebApi.Models.Promotion;

namespace Restaurant.WebApi.Controllers
{
    [Route("admin/promotion")]
    public class AdminPromotionController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePromotionDto dto)
        {
            var command = _mapper.Map<CreatePromotionCommand>(dto);
            var id = await Mediator.Send(command);

            return Ok(id);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdatePromotionDto dto)
        {
            var command = _mapper.Map<UpdatePromotionCommand>(dto);
            command.Id = id;
            await Mediator.Send(command);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeletePromotionCommand { Id = id };
            await Mediator.Send(command);

            return Ok(id);
        }
    }
}
