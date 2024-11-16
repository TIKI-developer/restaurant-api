using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Promotion.Queries.GetPromotion;
using Restaurant.Application.Entities.Promotion.Queries.GetPromotionList;

namespace Restaurant.WebApi.Controllers
{
    [Route("promotions")]
    public class PromotionController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionDetailsViewModel>> GetDetails(Guid id)
        {
            var query = new GetPromotionQuery { Id = id };
            var promotion = await Mediator.Send(query);

            return Ok(promotion);
        }
        [HttpGet]
        public async Task<ActionResult<PromotionListViewModel>> GetList()
        {
            var query = new GetPromotionListQuery();
            var promotionsVm = await Mediator.Send(query);

            return Ok(promotionsVm);
        }
    }
}
