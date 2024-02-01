using Microsoft.AspNetCore.Http;

namespace BasePerson.Application.Services
{
    public interface IImageService
    {
        Task<string> UploadImage(IFormFile imageFile);
    }
}
