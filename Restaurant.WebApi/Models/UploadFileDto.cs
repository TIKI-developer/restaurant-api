namespace Restaurant.WebApi.Models
{
    public class UploadFileDto
    {
        public required IFormFile[] Files { get; set; }
        public string? RelativePath { get; set; }
    }
}
