using Domain.Entities;

namespace Infrastructure.Services;

public interface IFileServices
{
        Task<Response<string>> InsertFile(FileUpload upload);
}
