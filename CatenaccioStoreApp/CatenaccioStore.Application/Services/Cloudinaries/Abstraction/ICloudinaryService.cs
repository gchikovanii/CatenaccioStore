using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenaccioStore.Application.Services.Cloudinaries.Abstraction
{
    public interface ICloudinaryService
    {
        Task<ImageUploadResult> UploadImage(IFormFile file);
        Task<List<ImageUploadResult>> UploadImages(List<IFormFile> files);
        Task<DeletionResult> DeleteImage(string publicKey);
    }
}
