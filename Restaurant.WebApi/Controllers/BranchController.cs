using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands;
using Restaurant.Application.Queries;
using Restaurant.Application.ViewModels;
using Restaurant.WebApi.Models;

namespace Restaurant.WebApi.Controllers
{
    [Route("branches")]
    public class BranchController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBranchDto dto)
        {
            var command = _mapper.Map<CreateBranchCommand>(dto);
            var id = await Mediator.Send(command);

            return Ok(id);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBranchDto dto) 
        {
            var command = _mapper.Map<UpdateBranchCommand>(dto);
            command.Id = id;
            await Mediator.Send(command);

            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBranchCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<BranchList>> Get()
        {
            var query = new GetBranchListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpGet("published")]
        public async Task<ActionResult<BranchList>> GetPublished()
        {
            var query = new GetPublishedBranchListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BranchDetails>> GetBy(Guid id)
        {
            var query = new GetBranchByIdQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
