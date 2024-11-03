using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Category.Queries.GetCategory;
using Restaurant.Application.Entities.Category.Queries.GetCategoryList;

namespace Restaurant.WebApi.Controllers
{
    [Route("categories")]
    [Authorize(Roles = "Admin, Client")]
    public class CategoryController : BaseController
    {
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
        [HttpGet]
        public async Task<ActionResult<CategoryListViewModel>> GetCategoryList()
        {
            var query = new GetCategoryListQuery();

            var vm = await Mediator.Send(query);
             
            return Ok(vm);
        }
    }
}
