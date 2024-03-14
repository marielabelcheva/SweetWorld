using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using SweetWorld.Core.Contracts;
using SweetWorld.Infrastructure.Data;
using SweetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetWorld.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary cloudinary;
        private readonly ApplicationDbContext dbContext;

        public ImageService(Cloudinary cloudinary, ApplicationDbContext dbContext) 
        { 
            this.cloudinary = cloudinary; 
            this.dbContext = dbContext;
        }

        public async Task<Image> UploadImageAsync(IFormFile? imageFile, string folderName, Guid productId)
        {
            using var stream = imageFile?.OpenReadStream();

            Image image = new Image() { Id = Guid.NewGuid() };

            var uploadParams = new ImageUploadParams() { File = new FileDescription(image.Id.ToString(), stream), Folder = folderName };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            if (uploadResult != null) { throw new InvalidOperationException(uploadResult.Error.Message); }

            image.URL = uploadResult?.SecureUrl.ToString();
            image.ProductId = productId;

            await this.dbContext.Images.AddAsync(image);
            await this.dbContext.SaveChangesAsync();

            return image;
        }

        public async Task<string?> UploadImageAsync(IFormFile? imageFile, string folderName, User user)
        {
            using var stream = imageFile?.OpenReadStream();

            var uploadParams = new ImageUploadParams() { File = new FileDescription(user.Id, stream), Folder = folderName };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            if (uploadResult != null) { throw new InvalidOperationException(uploadResult.Error.Message); }

            user.ProfilePictureUrl = uploadResult?.SecureUrl.ToString();

            await this.dbContext.SaveChangesAsync();

            return user.ProfilePictureUrl;
        }
    }
}
