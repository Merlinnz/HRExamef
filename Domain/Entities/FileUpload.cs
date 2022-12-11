using Microsoft.AspNetCore.Http;

namespace Domain.Entities;

public class FileUpload
{
    public IFormFile? File { get; set; }
}
