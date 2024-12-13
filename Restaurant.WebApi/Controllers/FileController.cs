using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.WebApi.Models.File;

namespace Restaurant.WebApi.Controllers
{
    [Route("files")]
    public class FileController : BaseController
    {
        private readonly string _baseFolderPath;

        public FileController()
        {
            _baseFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            EnsureBaseFolderExists();
        }

        private void EnsureBaseFolderExists()
        {
            if (!Directory.Exists(_baseFolderPath))
            {
                Directory.CreateDirectory(_baseFolderPath);
            }
        }

        private string GetFilePath(string relativePath)
        {
            return Path.Combine(_baseFolderPath, relativePath);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<string[]> Upload([FromForm] UploadFileDto uploadFileDto)
        {
            var formFiles = uploadFileDto.Files;
            var relativePath = string.IsNullOrEmpty(uploadFileDto.RelativePath) ? "uploads/" : uploadFileDto.RelativePath;
            var uniqueFileNames = new List<string>();

            foreach (var formFile in formFiles)
            {
                if (formFile == null || formFile.Length == 0)
                {
                    throw new Exception("Файл не был выбран");
                }

                var filePath = GetFilePath(relativePath);
                var directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath!);
                }

                var uniqueFileName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);
                var fullPath = Path.Combine(directoryPath!, uniqueFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
                uniqueFileNames.Add(uniqueFileName);
            }

            return uniqueFileNames.ToArray();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromBody] DeleteFileDto deleteFileDto)
        {
            var relativeFilePath = deleteFileDto.FilePath;

            if (string.IsNullOrEmpty(relativeFilePath))
            {
                return StatusCode(404, "Относительный путь не указан.");
            }

            var filePath = GetFilePath(relativeFilePath);

            if (!System.IO.File.Exists(filePath))
            {
                return StatusCode(404, "Файл не найден");
            }

            try
            {
                System.IO.File.Delete(filePath);
                return StatusCode(200, "Файл успешно удален.");
            }
            catch (IOException ex)
            {
                return StatusCode(500, $"Ошибка при удалении файла: {ex.Message}");
            }
        }
    }
}