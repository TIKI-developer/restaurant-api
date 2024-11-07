namespace Restaurant.WebApi
{
    public class FileLoader
    {
        public async Task<string> SaveFile(IFormFile file, string relPath = "")
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads/");
            uploadsFolder = Path.Combine(uploadsFolder, relPath);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return uniqueFileName;
        }
    }
}
