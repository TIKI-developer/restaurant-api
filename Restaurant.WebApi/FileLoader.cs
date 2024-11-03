namespace Restaurant.WebApi
{
    public class FileLoader
    {
        public string SaveFile(IFormFile file, string relPath = "")
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads/");
            uploadsFolder = Path.Combine(uploadsFolder, relPath);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return uniqueFileName;
        }
    }
}
