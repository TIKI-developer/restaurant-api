using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebApi.Controllers
{
    [Route("files")]
    public class FileController : BaseController
    {
        [HttpGet("images/{imageName}")]
        [Authorize(Roles = "Admin, Client")]
        public async Task<ActionResult> GetImage(string imageName)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads/Images/");
            var filePath = uploadsFolder + imageName;

            if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, "image/jpeg");
        }
    }
}
