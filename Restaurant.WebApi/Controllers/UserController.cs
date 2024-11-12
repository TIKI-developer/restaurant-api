using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Restaurant.WebApi.Controllers
{
    [Route("user")]
    public class UserController : BaseController
    {
        [HttpGet("role")]
        public async Task<ActionResult<string>> RegisterAdmin()
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(role))
            {
                role = "Guest";
            }

            return Ok(role);
        }
    }
}
