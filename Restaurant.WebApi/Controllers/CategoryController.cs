using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Category.Queries.GetCategory;
using Restaurant.Application.Entities.Category.Queries.GetCategoryList;


namespace Restaurant.WebApi.Controllers
{
    [Authorize(Roles = "Admin, Client")]
    [Route("categories")]
    public class CategoryController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

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
        [HttpGet()]
        public async Task<ActionResult<CategoryListViewModel>> GetCategoryList()
        {
            var query = new GetCategoryListQuery();

            var vm = await Mediator.Send(query);
             
            return Ok(vm);
        }
    }
}
