using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Entities.Dish.Commands.DeleteDish;
using Restaurant.Application.Entities.Dish.Queries.GetDishDetails;
using Restaurant.Application.Entities.Dish.Queries.GetDishList;
using Microsoft.AspNetCore.Authorization;
using Restaurant.Application.Entities.Dish.Commands.CreateDish;
using Restaurant.Application.Entities.Dish.Commands.UpdateDish;
using Restaurant.WebApi.Models.Dish;


namespace Restaurant.WebApi.Controllers
{
    [Route("dish")]
    public class DishController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [Authorize(Roles = "Admin, Client")]
        [HttpGet("{id}")]
        public async Task<ActionResult<DishDetailsViewModel>> Get(Guid id)
        {
            var query = new GetDishDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        //[Authorize(Roles = "Admin, Client")]
        [HttpGet("list")]
        public async Task<ActionResult<DishListViewModel>> GetAll()
        {
            var query = new GetDishListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [Authorize(Roles = "Admin, Client")]
        [HttpGet("list/{categoryId}")]
        public async Task<ActionResult<DishListViewModel>> GetDishesWithCategory(Guid categoryId)
        {
            var query = new GetCategoryDishListQuery
            {
                CategoryId = categoryId
            };
            query.CategoryId = categoryId;
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
