using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebApi.Controllers
{
    [Route("files")]
    public class FileController(FileLoader fileLoader) : BaseController
    {
        private readonly FileLoader _fileLoader = fileLoader;

        [HttpGet("images/{imageName}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetImage(string imageName)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads/images/");
            var filePath = uploadsFolder + imageName;

            if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, "image/jpeg");
        }
        [HttpPost("upload")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Upload(IFormFile formFile)
        {
            await _fileLoader.SaveFile(formFile);

            return Ok();
        }
        [HttpDelete("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(IFormFile formFile)
        {
            await _fileLoader.SaveFile(formFile);

            return Ok();
        }
    }
}
