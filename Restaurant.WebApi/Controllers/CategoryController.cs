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
    [Route("category")]
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
    }
}
