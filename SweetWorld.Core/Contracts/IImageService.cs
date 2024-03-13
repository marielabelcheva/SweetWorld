using Microsoft.AspNetCore.Http;

namespace SweetWorld.Core.Contracts
{
    public interface IImageService
    {
        public Task<string> UploadImageAsync(IFormFile imageFile, string name);
    }
}
