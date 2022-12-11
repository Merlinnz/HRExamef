using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class FileController
{
    private readonly IFileServices _fileServices;

    public FileController(IFileServices fileService)
    {
        _fileServices = fileService;
    }

    [HttpPost("Insert")]
    public async Task<Response<string>> Insert([FromForm] FileUpload fileUpload)
    {
        return await _fileServices.InsertFile(fileUpload);
    }
}

