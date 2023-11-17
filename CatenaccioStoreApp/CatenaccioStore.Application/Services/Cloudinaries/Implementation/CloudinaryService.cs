using CatenaccioStore.Application.Services.Cloudinaries.Abstraction;
using CatenaccioStore.Application.Services.Configurations;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Application.Services.Cloudinaries.Implementation
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySetting> cloudinarySettings)
        {
            var setting = cloudinarySettings.Value;
            var account = new Account() { ApiKey = setting.ApiKey, ApiSecret = setting.ApiSecret, Cloud = setting.Cloud };
            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> UploadImage(IFormFile file)
        {
            var result = new ImageUploadResult();
            if (result != null)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams() { File = new FileDescription(file.FileName, stream) };
                result = await _cloudinary.UploadAsync(uploadParams);
            }
            return result;
        }
        public async Task<List<ImageUploadResult>> UploadImages(List<IFormFile> files)
        {
            var results = new List<ImageUploadResult>();

            foreach (var file in files)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream)
                };

                var result = await _cloudinary.UploadAsync(uploadParams);
                results.Add(result);
            }

            return results;
        }
        public async Task<DeletionResult> DeleteImage(string publicKey)
        {
            return await _cloudinary.DestroyAsync(new DeletionParams(publicKey));
        }

    }
}
