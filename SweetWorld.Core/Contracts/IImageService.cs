using Microsoft.AspNetCore.Http;
using SweetWorld.Infrastructure.Data.Models;

namespace SweetWorld.Core.Contracts
{
    public interface IImageService
    {
        public Task<Image> UploadImageAsync(IFormFile? imageFile, string folderName, Guid? productId);

        public Task<string?> UploadImageAsync(IFormFile? imageFile, string folderName, User user); 
    }
}
